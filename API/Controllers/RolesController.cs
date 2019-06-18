using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using Application.Commands.RoleCommands;
using Application.DTO;
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
    public class RolesController : ControllerBase
    {
        private IGetRoleCommand _getRole;
        private IGetSingleRoleCommand _getSingleRole;
        private IInsertRoleCommand _insertRole;
        private IUpdateRoleCommand _updateRoleCommand;
        private IDeleteRoleCommand _deleteRoleCommand;
        public RolesController(IGetRoleCommand getRoleCommand, IGetSingleRoleCommand getSingleRoleCOmmand, IInsertRoleCommand insertRoleCommand, IUpdateRoleCommand updateRoleCommand, IDeleteRoleCommand deleteRoleCommand)
        {
            _getRole = getRoleCommand;
            _getSingleRole = getSingleRoleCOmmand;
            _insertRole = insertRoleCommand;
            _updateRoleCommand = updateRoleCommand;
            _deleteRoleCommand = deleteRoleCommand;
        }

        // GET: api/Roles
        [HttpGet]
		public ActionResult<IEnumerable<RoleResponseDTO>> Get([FromQuery] RoleSearch search)
        {
            var result = _getRole.Execute(search);
            return Ok(result);
        }

        // GET: api/Roles/5
        [HttpGet("{id}", Name = "Get2")]
        public ActionResult<RoleResponseDTO> Get(int id)
        {
            try
            {
                var result = _getSingleRole.Execute(id);
                return Ok(result);
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

        // POST: api/Roles
        [HttpPost]
		[LoggedIn("Admin")]
		public ActionResult<RoleResponseDTO> Post([FromBody] RoleRequestDTO dto)
        {
			try
			{
				var role = _insertRole.Execute(dto);
				return Created("api/roles/" + role.Id, role);
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

        // PUT: api/Roles/5
        [HttpPut("{id}")]
		[LoggedIn("Admin")]
		public IActionResult Put(int id, [FromBody] RoleRequestDTO roleDTO)
        {
            try
            {
                _updateRoleCommand.Execute(id, roleDTO);
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
				_deleteRoleCommand.Execute(id);
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
