using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO.RequestDTO
{
	public class UserRequestDTO
	{
		[Required]
		[MinLength(2, ErrorMessage = "First name must be longer than 2")]
		public string FirstName { get; set; }
		[Required]
		[MinLength(2, ErrorMessage = "Last name must be longer than 2")]
		public string LastName { get; set; }
		[Required]
		[MinLength(5, ErrorMessage = "Username must be longer than 2")]
		public string Username { get; set; }
		[Required]
		[MinLength(2, ErrorMessage = "Password must be longer than 2")]
		public string Password { get; set; }
		public int? RoleId { get; set; }
	}
}
