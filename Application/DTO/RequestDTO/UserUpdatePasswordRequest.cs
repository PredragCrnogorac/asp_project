using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO.RequestDTO
{
	public class UserUpdatePasswordRequest
	{
		
		[Required]
		[MinLength(2, ErrorMessage = "Password must be longer than 2")]
		public string Password { get; set; }
	}
}
