using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using Application.Commands.ExtraAddonsCommands;
using Application.DTO.RequestDTO;
using Application.DTO.ResponseDTO;
using Application.Exceptions;
using Application.Searches.ExtraAddonsSearches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtraaddonsController : ControllerBase
    {
        private readonly IGetExtraAddonsCommand _getExtras;
        private readonly IInsertExtraAddonCommand _insertExtras;
        private readonly IGetSingleExtraAddonCommand _getSingleExtras;
        private readonly IDeleteExtraAddonCommand _deleteExtra;
        private readonly IUpdateExtraAddonCommand _updateExtra;
        public ExtraaddonsController(IGetExtraAddonsCommand getExtra, IInsertExtraAddonCommand insertExtraAddon, IGetSingleExtraAddonCommand getSingleExtraAddon, IDeleteExtraAddonCommand deleteExtraAddon, IUpdateExtraAddonCommand updateExtraAddon)
        {
            _getExtras = getExtra;
            _insertExtras = insertExtraAddon;
            _getSingleExtras = getSingleExtraAddon;
            _deleteExtra = deleteExtraAddon;
            _updateExtra = updateExtraAddon;
        }
        // GET: api/Extraaddon
        [HttpGet]
        public ActionResult<IEnumerable<ExtraAddonResponseDTO>> Get([FromQuery] ExtraAddonSearchName name)
        {
                var extras = _getExtras.Execute(name);
                return Ok(extras);
        }

        // GET: api/Extraaddon/5
        [HttpGet("{id}", Name = "GetExtraAddons")]
        public ActionResult<ExtraAddonResponseDTO> Get(int id)
        {
            try
            {
                var extra = _getSingleExtras.Execute(id);
                return Ok(extra);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // POST: api/Extraaddon
        [HttpPost]
		[LoggedIn("Admin")]
		public ActionResult<ExtraAddonResponseDTO> Post([FromBody] ExtraAddonRequestDTO value)
        {
            var extra = _insertExtras.Execute(value);
            return Created("api/extraaddons/" + extra.Id, extra);
        }

        // PUT: api/Extraaddon/5
        [HttpPut("{id}")]
		[LoggedIn("Admin")]
		public IActionResult Put(int id, [FromBody] ExtraAddonRequestDTO value)
        {
            try
            {
                _updateExtra.Execute(id, value);
                return NoContent();
            }
            catch(EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch(EntityUnchangedException e)
            {
                return Conflict(e.Message);
            }
            catch (EntityExistsException e)
            {
                return Conflict(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
		[LoggedIn("Admin")]
		public void Delete(int id)
        {
        }
    }
}
