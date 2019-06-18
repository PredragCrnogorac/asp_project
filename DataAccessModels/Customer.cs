using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessModels
{
	public class Customer : BaseEntity
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public DateTime Birthday { get; set; }
		public ICollection<Rent> Rents { get; set; }
	}
}
