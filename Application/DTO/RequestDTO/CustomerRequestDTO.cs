using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO.RequestDTO
{
	public class CustomerRequestDTO
	{
		[Required]
		[MinLength(2, ErrorMessage = "First name must be longer than 2")]
		public string FirstName { get; set; }
		[Required]
		[MinLength(2, ErrorMessage = "Last name must be longer than 2")]
		public string LastName { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string PhoneNumber { get; set; }
		[Required]
		public DateTime Birthday { get; set; }
	}
}
