using Application.DTO.RequestDTO;
using Application.DTO.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
	public class UserUpdateViewBag
	{
		public UserResponseDTO UserResponseDTO { get; set; }

		public UserUpdateRequestDTO UserDTO { get; set; }
		public IEnumerable<RoleResponseDTO> Roles { get; set; }
	}
}
