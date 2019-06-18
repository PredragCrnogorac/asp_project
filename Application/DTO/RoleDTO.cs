using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class RoleDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Usernames { get; set; }
    }
}
