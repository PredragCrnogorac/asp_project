using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Application.DTO.RequestDTO;
using Application.Commands.UserCommands;
using EFCommands.BrandCommands;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

		private readonly Encryption _enc;
		readonly IGetLoggedUser _getLoggedUser;
		public AuthController(Encryption enc, IGetLoggedUser getLoggedUser)
		{
			_enc = enc;
			_getLoggedUser = getLoggedUser;
		}

		// POST: api/Auth
		[HttpPost]
		public IActionResult Post([FromBody] UserLogginDTO dto)
		{
			var user = _getLoggedUser.Execute(dto);
			var userl = new LoggedUser();
			userl.Id = user.Id;
			userl.FirstName = user.FirstName;
			userl.LastName = user.LastName;
			userl.Role = user.RoleName;
			userl.Username = user.Username;


			var stringObjekat = JsonConvert.SerializeObject(userl);

			var encrypted = _enc.EncryptString(stringObjekat);

			return Ok(new { token = encrypted });
		}

		//[HttpGet("decode")]
		//public IActionResult Decode(string value)
		//{
		//	var decodedString = _enc.DecryptString(value);
		//	decodedString = decodedString.Replace("\f", "");
		//	var user = JsonConvert.DeserializeObject<LoggedUser>(decodedString);

		//	return null;
		//}
	}
}
