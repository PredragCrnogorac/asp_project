using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Commands.RentCommands;
using Application.Searches.RentSearches;
using Application.Exceptions;
using API.Helpers;
using Application.DTO.RequestDTO.RentRequestDTO;
using Application.DTO;
using Application.DTO.ResponseDTO.RentResponseDTO;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
    public class RentsController : ControllerBase
    {
		readonly IGetRentsCommand _getRents;
		readonly IGetSIngleRentCommand _getRent;
		readonly IInsertRentCommand _insertRent;
		readonly IUpdateRentCommand _updateRent;
		readonly IDeleteRentCommand _deleteRent;
		readonly IStartRentCommand _startRent;
		readonly IFinishRentCommand _finishRent;

		public RentsController(IFinishRentCommand finishRent,IStartRentCommand startRent,IGetRentsCommand getRents, IGetSIngleRentCommand getRent, IInsertRentCommand insertRent, IUpdateRentCommand updateRent, IDeleteRentCommand deleteRent)
		{
			_finishRent = finishRent;
			_startRent = startRent;
			_getRents = getRents;
			_getRent = getRent;
			_insertRent = insertRent;
			_updateRent = updateRent;
			_deleteRent = deleteRent;
		}

		// GET: api/Rents
		
		[HttpGet] 
        public ActionResult<PagedResponseDTO<RentResponseDTO>> Get([FromQuery] RentSearch search)
        {
			try
			{
				var rents = _getRents.Execute(search);
				return Ok(rents);
			}
			catch(Exception)
			{
				return StatusCode(500, "Server error");
			}
        }

		// GET: api/Rents/5
		[HttpGet("{id}")]
        public ActionResult<RentResponseDTO> Get(int id)
        {
			try
			{
				var rent = _getRent.Execute(id);
				return Ok(rent);
			}
			catch(EntityNotFoundException e)
			{
				return NotFound(e.Message);
			}
			catch (Exception)
			{
				return StatusCode(500, "Server error");
			}
        }

        // POST: api/Rents
		/*
		 * Inserting new rent with default status : Reserved
		 * Vehicle status Rented is set to true and can't be rented again
		 */
        [HttpPost]
		[LoggedIn("Admin")]
        public ActionResult<RentResponseDTO> Post([FromBody] RentRequestDTO value)
        {
			try
			{
				var rent = _insertRent.Execute(value);
				return Created("api/rents/" + rent.Id, rent);
			}
			catch(EntityNotFoundException e)
			{
				return NotFound(e.Message);
			}
			catch (EntityExistsException)
			{
				return Conflict("Vehicle is already rented");
			}
			catch (ArgumentOutOfRangeException)
			{
				return Conflict("Returning date must be after pickup date");
			}
			catch (Exception)
			{
				return StatusCode(500, "Server error");
			}
			
		}

		// PUT: api/Rents/5
		/*
		 * Updating rent which is in Reserved status, otherwise updating is disabled
		 */
		[HttpPut("{id}")]
		[LoggedIn("Admin")]
        public IActionResult Put(int id, [FromBody] RentUpdateRequestDTO value)
        {
			try
			{
				_updateRent.Execute(id, value);
				return NoContent();
			}
			catch(EntityNotFoundException e)
			{
				return NotFound(e.Message);
			}
			catch (IndexOutOfRangeException)
			{
				return Conflict("You can't mofify rents which are in progress.");
			}
			catch (EntityExistsException)
			{
				return Conflict("Vehicle is already rented.");
			}
			catch (ArgumentOutOfRangeException)
			{
				return Conflict("Returning date must be after pickup date");
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
				_deleteRent.Execute(id);
				return NoContent();
			}
			catch(EntityNotFoundException e)
			{
				return NotFound(e.Message);
			}
			catch (EntityExistsException)
			{
				return Conflict("You can't delete rents which are in progress.");
			}
			catch (Exception)
			{
				return StatusCode(500, "Server error");
			}
		}
		/*
		 * Starting rent, customer has picked up vehicle. Updating is disabled and status set to: In Progress
		 */
		
		[HttpPost("start/{id}")]
		[LoggedIn("Admin")]
		public IActionResult Start(int id)
		{
			try
			{
				_startRent.Execute(id);
				return NoContent();
			}
			catch (IndexOutOfRangeException)
			{
				return Conflict("You can only start rent which is in reservation status.");
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
		/*
		 * Finishing rent, customer has returned vehicle. Rent status is set to: Returned
		 * Vehicle status Rented is set to false, and can be rented again
		 */
		
		[HttpPost("finish/{id}")]
		[LoggedIn("Admin")]
		public IActionResult Finish(int id)
		{
			try
			{
				_finishRent.Execute(id);
				return NoContent();
			}
			catch (IndexOutOfRangeException)
			{
				return Conflict("You can only stop rent which is in progress status.");
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
