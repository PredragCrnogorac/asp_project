using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.ResponseDTO.StatusResponseDTO
{
	public class StatusRentResponseDTO
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int CustomerId { get; set; }
		public int VehicleId { get; set; }
		public string VehicleModel { get; set; }
		public int LocationId { get; set; }
		public int DropLocationId { get; set; }
		public DateTime PickDate { get; set; }
		public DateTime DropDate { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string PickAdress { get; set; }
		public string DropAdress { get; set; }
		public double VehicleCostPerDay { get; set; }
		public double TotallPrice { get; set; }
		public IEnumerable<RentExtraAddonResponseDTO> RentExtraAddons { get; set; }
	}
}
