using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.ResponseDTO.StatusResponseDTO
{
	public class StatusResponseDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public IEnumerable<StatusRentResponseDTO> Rents { get; set; }
	}
}
