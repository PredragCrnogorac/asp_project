using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using Application.Commands.CustomerCommands;
using Application.DTO.RequestDTO;
using Application.DTO.ResponseDTO;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
		private IGetCustomersCommand _getCustomers;
		private IGetSingleCustomerCommand _getSingleCustomer;
		private IInsertCustomerCommand _insertCustomer;
		private IUpdateCustomerCommand _updateCustomer;
		private IDeleteCustomerCommand _deleteCustomer;

		public CustomersController(IGetCustomersCommand getCustomerss, IGetSingleCustomerCommand getSingleCustomer, IInsertCustomerCommand insertCustomer, IUpdateCustomerCommand updateCustomer, IDeleteCustomerCommand deleteCustomer)
		{
			_getCustomers = getCustomerss;
			_getSingleCustomer = getSingleCustomer;
			_insertCustomer = insertCustomer;
			_updateCustomer = updateCustomer;
			_deleteCustomer = deleteCustomer;
		}

		// GET: api/Customer
		[HttpGet]
		public ActionResult<IEnumerable<CustomerResponseDTO>> Get([FromQuery]CustomerSearch query)
		{
			var result = _getCustomers.Execute(query);
			return Ok(result);
		}

		// GET: api/Users/5
		[HttpGet("{id}")]
		public ActionResult<CustomerResponseDTO> Get(int id)
		{
			try
			{
				var result = _getSingleCustomer.Execute(id);
				return Ok(result);
			}
			catch (EntityNotFoundException e)
			{
				return NotFound(e.Message);
			}
			catch (Exception e)
			{
				return StatusCode(500, e.ToString());
			}
		}

		[HttpPost]
		[LoggedIn("Admin")]
		public ActionResult<CustomerResponseDTO> Post([FromBody] CustomerRequestDTO customer)
		{
			try
			{
				var result = _insertCustomer.Execute(customer);
				return Created("api/users/" + result.Id, result);
			}
			catch (EntityNotFoundException e)
			{
				return NotFound(e.Message);
			}
			catch (EntityExistsException e)
			{
				return Conflict(e.Message);
			}
			catch (Exception)
			{
				return StatusCode(500, "ServerError");
			}
		}

		// PUT: api/Users/5
		[HttpPut("{id}")]
		[LoggedIn("Admin")]
		public IActionResult Put(int id, [FromBody] CustomerRequestDTO dto)
		{
			
			try
			{
				_updateCustomer.Execute(id, dto);
				return NoContent();
			}
			catch (EntityNotFoundException e)
			{
				return NotFound(e.Message);
			}
			catch (EntityExistsException e)
			{
				return Conflict(e.Message);
			}
			catch (Exception)
			{
				return StatusCode(500, "Server error");
			}
		}

		// DELETE: api/ApiWithActions/5
		[HttpDelete("{id}")]
		[LoggedIn("Admin")]
		public IActionResult Delete(int id)
		{
			try
			{
				_deleteCustomer.Execute(id);
				return NoContent();
			}
			catch (EntityNotFoundException e)
			{
				return NotFound(e.Message);
			}
			catch (Exception)
			{
				return StatusCode(500, "Server error");
			}
		}
	}
}
