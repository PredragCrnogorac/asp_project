using Application.DTO;
using Application.DTO.RequestDTO;
using Application.DTO.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
	public class UserCreateViewBag
	{
		public UserRequestDTO UserDTO { get; set; }
		public IEnumerable<RoleResponseDTO> Roles { get; set; }
	}
}
