using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.ResponseDTO
{
	public class CustomerResponseDTO
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public DateTime Birthday { get; set; }
	}
}
