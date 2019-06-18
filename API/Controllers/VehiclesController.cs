using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using Application.Commands.VehicleCommands;
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
    public class VehiclesController : ControllerBase
    {
        private readonly IInsertVehicleCommand _insertVehicle;
        private readonly IGetVehiclesCommand _getVehicles;
        private readonly IGetSIngleVehicleCommand _getSingleVehicles;
        private readonly IDeleteVehicleCommand _deleteVehicle;
        private readonly IUpdateVehicleCommand _updateVehicle;
        public VehiclesController(IInsertVehicleCommand insertVehicle, IGetVehiclesCommand getVehicles, IGetSIngleVehicleCommand getSIngleVehicle, IDeleteVehicleCommand deleteVehicle, IUpdateVehicleCommand updateVehicle)
        {
			_insertVehicle = insertVehicle;
            _getVehicles = getVehicles;
			_getSingleVehicles = getSIngleVehicle;
			_deleteVehicle = deleteVehicle;
			_updateVehicle = updateVehicle;
        }
        // GET: api/Vehicles
        [HttpGet]
        public ActionResult<IEnumerable<VehicleResponseDTO>> Get([FromQuery] VehicleSearch search)
        {
            try
            {
                var vehicles = _getVehicles.Execute(search);
                return Ok(vehicles);
            }
            catch (Exception)
            {
                return StatusCode(500, "Server error");
            }
        }

        // GET: api/Vehicles/5
        [HttpGet("{id}", Name = "GetVehicle")]
        public ActionResult<VehicleResponseDTO> Get(int id)
        {
			try
			{
				var vehicle = _getSingleVehicles.Execute(id);
				return Ok(vehicle);
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

        // POST: api/Vehicles
        [HttpPost]
		[LoggedIn("Admin")]
		public ActionResult<VehicleResponseDTO> Post([FromBody] VehicleRequestDTO value)
        {
            try
            {
                var vehicle = _insertVehicle.Execute(value);
                return Created("api/vehicles/" + vehicle.Id, vehicle);
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

        // PUT: api/Vehicles/5
        [HttpPut("{id}")]
		[LoggedIn("Admin")]
		public IActionResult Put(int id, [FromBody] VehicleRequestDTO value)
        {
			try
			{
				_updateVehicle.Execute(id, value);
				return NoContent();
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

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
		[LoggedIn("Admin")]
		public IActionResult Delete(int id)
        {
			try
			{
				_deleteVehicle.Execute(id);
				return NoContent();
			}
			catch(EntityNotFoundException e)
			{
				return NotFound(e.Message);
			}
			catch (EntityExistsException)
			{
				return Conflict("You can't delete vehicle which is rented.");
			}
			catch (Exception)
			{
				return StatusCode(500, "Server error");
			}
        }
    }
}
