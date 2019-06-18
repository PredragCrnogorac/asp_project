using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO.RequestDTO.RentRequestDTO
{
	public class RentUpdateRequestDTO
	{
		[Required]
		public int UserId { get; set; }
		[Required]
		public int CustomerId { get; set; }
		[Required]
		public int VehicleId { get; set; }
		[Required]
		public int LocationId { get; set; }
		[Required]
		public int DropLocationId { get; set; }
		[Required]
		[DataType(DataType.Date)]
		public DateTime PickDate { get; set; }
		[Required]
		[DataType(DataType.Date)]
		public DateTime DropDate { get; set; }
		public ICollection<int> ExtraAddonIds { get; set; }
	}
}
