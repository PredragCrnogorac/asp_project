using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.DTO;
using Application.Searches;
using Application.Commands.UserCommands;
using Application.Exceptions;
using Application.DTO.RequestDTO;
using API.Helpers;
using Application.DTO.ResponseDTO;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IGetUsersCommand _getUsers;
        private IGetSingleUserCommand _getSingleUser;
        private IInsertUserCommand _insertUser;
        private IUpdateUserCommand _updateUser;
        private IDeleteUserCommand _deleteUser;
        public UsersController(IGetUsersCommand getUsers, IGetSingleUserCommand getSingleUser, IInsertUserCommand insertUser, IUpdateUserCommand updateUser, IDeleteUserCommand deleteUser)
        {
            _getUsers = getUsers;
            _getSingleUser = getSingleUser;
            _insertUser = insertUser;
            _updateUser = updateUser;
            _deleteUser = deleteUser;
        }
       
        // GET: api/Users
        [HttpGet]
        public ActionResult<IEnumerable<UserResponseDTO>> Get([FromQuery]UserSearch query)
        {
            var result = _getUsers.Execute(query);
            return Ok(result);
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<UserResponseDTO> Get(int id)
        {
            try
            {
                var result = _getSingleUser.Execute(id);
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

        // POST: api/Users
        [HttpPost]
		[LoggedIn("Admin")]
		public ActionResult<UserResponseDTO> Post([FromBody] UserRequestDTO user)
        {
			
            try
            {
                var result = _insertUser.Execute(user);
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
		public IActionResult Put(int id, [FromBody] UserUpdateRequestDTO dto)
        {
			
			try
			{
                _updateUser.Execute(id, dto);
                return NoContent();
            }
            catch (EntityNotFoundException e)
            {
				return NotFound(e.Message);
            }
            catch (EntityExistsException e)
            {
                return Conflict(e.Message);
            }catch(Exception)
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
                _deleteUser.Execute(id);
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
