using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessModels
{
	public class Rent : BaseEntity
	{
		//Basic information is stored because it might be changed in future
		public int UserId { get; set; }
		public User User { get; set; }
		public int CustomerId { get; set; }
		public Customer Customer { get; set; }
		public int VehicleId { get; set; }
		public Vehicle Vehicle { get; set; }
		public int LocationId { get; set; }
		public Location Location { get; set; }
		public int DropLocationId { get; set; }
		public Location DropLocation { get; set; }
		public DateTime PickDate { get; set; }
		public DateTime DropDate { get; set; }
		//Saving basic information about customer and person who rented vehicle
		public string	FirstName { get; set; }
		public string	LastName { get; set; }
		public string Email { get; set; }
		//Saving basic information about addresses
		public string PickAdress { get; set; }
		public string DropAdress { get; set; }
		//Saving basic information about vehicle price in moment
		public double VehicleCostPerDay { get; set; }
		//
		public double TotallPrice { get; set; }
		public int  StatusId { get; set; }
		public RentStatus RentStatus { get; set; }
		public ICollection<RentExtraAddon> RentExtraAddons { get; set; }
	}
}
