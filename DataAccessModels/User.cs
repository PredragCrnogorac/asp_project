using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessModels
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
		public string Password { get; set; }
		public int RoleId { get; set; }
        public Role Role { get; set; }
		public ICollection<Rent> Rents { get; set; }
	}
}
