using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.RentCommands;
using Application.DTO.RequestDTO.RentRequestDTO;
using Application.Exceptions;
using DataAccessModels;
using EFDataAccess;

namespace EFCommands.RentCommands
{
	public class EFUpdateRentCommand : BaseEFCommand, IUpdateRentCommand
	{
		public EFUpdateRentCommand(AIContext context) : base(context)
		{
		}

		public void Execute(int search, RentUpdateRequestDTO request)
		{
			var rent = AiContext.Rents
				.Find(search);
			if (rent == null || rent.IsDeleted == 1)
				throw new EntityNotFoundException("Rent");
			//Allowing modifying rent only in period of reservation
			//Status with id 9 is "Reserved" status
			if (rent.StatusId != 9)
				throw new IndexOutOfRangeException();
			//
			var user = AiContext.Users
				.Find(request.UserId);
			if (user == null || user.IsDeleted == 1)
				throw new EntityNotFoundException("User");
			var pickLocaton = AiContext.Locations
				.Find(request.LocationId);
			if (pickLocaton == null || pickLocaton.IsDeleted == 1)
				throw new EntityNotFoundException("Pick up location");
			var dropLocation = AiContext.Locations
				.Find(request.DropLocationId);
			if (dropLocation == null || dropLocation.IsDeleted == 1)
				throw new EntityNotFoundException("Drop off location");
			var customer = AiContext.Customers
				.Find(request.CustomerId);
			if (customer == null || customer.IsDeleted == 1)
				throw new EntityNotFoundException("Customer");
			var vehicle = AiContext.Vehicles
				.Find(request.VehicleId);
			if (vehicle == null || vehicle.IsDeleted == 1)
				throw new EntityNotFoundException("Vehicle");
			//If vehicle is rented renting won't be possible
			if (vehicle.Rented == true && vehicle.Id != rent.VehicleId)
				throw new EntityExistsException();
			//If it's not rented, column in vehicle 'Rented' is changed to true until renting status is 'Returned'
			//Previous vehicle status is set back to avaliable
			if(vehicle.Id != rent.VehicleId)
			{
				vehicle.Rented = true;
				vehicle.ModifiedAt = DateTime.Now;
				var previousVehicle = AiContext.Vehicles
				.Find(rent.VehicleId);
				previousVehicle.Rented = false;
				previousVehicle.ModifiedAt = DateTime.Now;
			}
			//
			rent.UserId = request.UserId;
			rent.CustomerId = request.CustomerId;
			rent.DropLocationId = request.DropLocationId;
			rent.LocationId = request.LocationId;
			rent.PickDate = request.PickDate;
			rent.DropDate = request.DropDate;
			rent.VehicleId = request.VehicleId;
			rent.FirstName = customer.FirstName;
			rent.LastName = customer.LastName;
			rent.Email = customer.Email;
			rent.VehicleCostPerDay = vehicle.CostPerDay;
			rent.PickAdress = pickLocaton.Adress;
			rent.DropAdress = dropLocation.Adress;
			rent.ModifiedAt = DateTime.Now;
			//Updating initial price based on vehicle cost, days and pickup location
			var days = Math.Ceiling((request.DropDate - request.PickDate).TotalDays);
			if (days <= 0)
				throw new ArgumentOutOfRangeException();
			rent.TotallPrice = vehicle.CostPerDay * days + pickLocaton.Price;
			//Updating Extra add-ons
			//Removing extra addons which were in old list and not in new
			var extraAddons = AiContext.RentExtraAddons
				.Where(x => x.RentId == rent.Id)
				.Select(x => x.ExtraAddonId);
			var newExtraAddons = request.ExtraAddonIds;
			var diffOldExtraAddons = extraAddons.Except(newExtraAddons);
			foreach(var x in diffOldExtraAddons)
			{
				var removeExtra = AiContext.RentExtraAddons
					.Where(b => b.RentId == rent.Id)
					.Where(b => b.ExtraAddonId == x)
					.FirstOrDefault();
				AiContext.Remove(removeExtra); 
				rent.TotallPrice -= removeExtra.Price;
			}
			//Adding addons which are in new list
			var diffNewExtraAddons = newExtraAddons.Except(extraAddons);
			foreach (var x in diffNewExtraAddons)
			{
				var extra = AiContext.ExtraAddons
					.Find(x);
				if (extra == null || extra.IsDeleted == 1)
					throw new EntityNotFoundException("Extra addon with id " + x);
				var extraAddonRent = new RentExtraAddon
				{
					RentId = rent.Id,
					ExtraAddonId = x,
					Price = AiContext.ExtraAddons
								.Where(e => e.Id == x)
								.Select(e => e.Price)
								.FirstOrDefault()
				};
				AiContext.RentExtraAddons
					.Add(extraAddonRent);
				rent.TotallPrice += extraAddonRent.Price;
			}
			AiContext.SaveChanges();
		}
	}
}
