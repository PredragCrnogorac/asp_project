using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using Application.Commands.StatusCommands;
using Application.DTO.RequestDTO;
using Application.DTO.ResponseDTO.StatusResponseDTO;
using Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusesController : ControllerBase
    {
		private readonly IGetStatusesCommand _getStatuses;
		private readonly IGetSingleStatusCommand _getSIngleStatus;
		private readonly IInsertStatusCommand _insertStatus;
		private readonly IDeleteStatusCommand _deleteStatus;
		private readonly IUpdateStatusCommand _updateStatus;

		public StatusesController(IGetStatusesCommand getStatuses, IGetSingleStatusCommand getSIngleStatus, IInsertStatusCommand insertStatus, IDeleteStatusCommand deleteStatus, IUpdateStatusCommand updateStatus)
		{
			_getStatuses = getStatuses;
			_getSIngleStatus = getSIngleStatus;
			_insertStatus = insertStatus;
			_deleteStatus = deleteStatus;
			_updateStatus = updateStatus;
		}



		// GET: api/Statuses
		[HttpGet]
        public ActionResult<IEnumerable<StatusResponseDTO>> Get()
        {
			try
			{
				//Not doing searching for statuses
				var statuses = _getStatuses.Execute(null);
				return Ok(statuses);
			}
			catch (Exception)
			{
				return StatusCode(500, "Server error");
			}
        }

        // GET: api/Statuses/5
        [HttpGet("{id}")]
        public ActionResult<StatusResponseDTO> Get(int id)
        {
			try
			{
				var status = _getSIngleStatus.Execute(id);
				return Ok(status);
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

        // POST: api/Statuses
        [HttpPost]
		[LoggedIn("Admin")]
		public ActionResult<StatusResponseDTO> Post([FromBody] StatusRequestDTO value)
        {
			try
			{
				var status = _insertStatus.Execute(value);
				return Created("api/statuses/" + status.Id, status);
			}
			catch(EntityExistsException e)
			{
				return Conflict(e.Message);
			}
			catch(Exception)
			{
				return StatusCode(500, "Server error");
			}
        }

        // PUT: api/Statuses/5
        [HttpPut("{id}")]
		[LoggedIn("Admin")]
		public IActionResult Put(int id, [FromBody] StatusRequestDTO value)
        {
			try
			{
				_updateStatus.Execute(id, value);
				return NoContent();
			}
			catch(EntityNotFoundException e)
			{
				return NotFound(e.Message);
			}
			catch(EntityExistsException e)
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
				_deleteStatus.Execute(id);
				return NoContent();
			}
			catch(EntityNotFoundException e)
			{
				return NotFound(e.Message);
			}
			catch (EntityExistsException)
			{
				return Conflict("This status is used in existing Rents. Deleting it will result in the loss of data.");
			}
			catch (Exception)
			{
				return StatusCode(500, "Server error");
			}
        }
    }
}
