using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class UserDTO
    {
		
        public int? Id { get; set; }
		[Required]
		[MinLength(2, ErrorMessage ="First name must be longer than 2")]
		public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
        //public string GroupName { get; set; }
    }
}
