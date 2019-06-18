using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using Application.Commands.VehicleTypeCommands;
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
    public class VehicletypesController : ControllerBase
    {
        private readonly IGetVehicleTypesCommand _getVehicleTypes;
        private readonly IGetSIngleVehicleTypeCommand _getSIngleVehicleType;
        private readonly IInsertVehicleTypeCommand _insertVehicleType;
        private readonly IDeleteVehicleTypeCommand _deleteVehicleType;
        private readonly IUpdateVehicleTypeCommand _updateVehicleType;
        public VehicletypesController(IGetVehicleTypesCommand getVehicleTypes, IGetSIngleVehicleTypeCommand getSIngleVehicleType, IInsertVehicleTypeCommand insertVehicleType, IDeleteVehicleTypeCommand deleteVehicleType, IUpdateVehicleTypeCommand updateVehicleType)
        {
            _getVehicleTypes = getVehicleTypes;
            _getSIngleVehicleType = getSIngleVehicleType;
            _insertVehicleType = insertVehicleType;
            _deleteVehicleType = deleteVehicleType;
            _updateVehicleType = updateVehicleType;
        }
        // GET: api/VehicleTypes
        [HttpGet]
        public ActionResult<IEnumerable<VehicleTypeResponseDTO>> Get([FromQuery]VehicleTypeSearch name)
        {
            try
            {
                var vehtypes = _getVehicleTypes.Execute(name);
                return Ok(vehtypes);
            }
            catch (Exception)
            {
                return StatusCode(500, "Server error");
            }
        }

        // GET: api/VehicleTypes/5
        [HttpGet("{id}", Name = "GetVehicleTypes")]
        public ActionResult<VehicleTypeResponseDTO> Get(int id)
        {
            try
            {
                var vehType = _getSIngleVehicleType.Execute(id);
                return Ok(vehType);
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

        // POST: api/VehicleTypes
        [HttpPost]
		[LoggedIn("Admin")]
		public ActionResult<VehicleTypeResponseDTO> Post([FromBody] VehicleTypeRequestDTO value)
        {
            try
            {
                var vehType = _insertVehicleType.Execute(value);
                return Created("api/vehicletypes/" + vehType.Id, vehType);
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

        // PUT: api/VehicleTypes/5
        [HttpPut("{id}")]
		[LoggedIn("Admin")]
		public IActionResult Put(int id, [FromBody] VehicleTypeRequestDTO value)
        {
            try
            {
                _updateVehicleType.Execute(id, value);
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
                _deleteVehicleType.Execute(id);
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
    }
}
