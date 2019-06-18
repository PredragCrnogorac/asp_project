using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.RentCommands;
using Application.DTO.RequestDTO.RentRequestDTO;
using Application.DTO.ResponseDTO;
using Application.DTO.ResponseDTO.RentResponseDTO;
using Application.Exceptions;
using Application.Interfaces;
using DataAccessModels;
using EFDataAccess;

namespace EFCommands.RentCommands
{
	public class EFInsertRentCommand : BaseEFCommand, IInsertRentCommand
	{
		readonly IEmailSender _emailSender;
		public EFInsertRentCommand(AIContext context, IEmailSender emailSender) : base(context)
		{
			_emailSender = emailSender;
		}

		public RentResponseDTO Execute(RentRequestDTO request)
		{
			
			var rent = new Rent();
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
			int statusId = request.StatusId.HasValue ? request.StatusId.GetValueOrDefault() : 9;
			var status = AiContext.RentStatus
				.Find(statusId);
			if (status == null || status.IsDeleted == 1)
				throw new EntityNotFoundException("Rent status");
			var customer = AiContext.Customers
				.Find(request.CustomerId);
			if (customer == null || customer.IsDeleted == 1)
				throw new EntityNotFoundException("Customer");
			var vehicle = AiContext.Vehicles
				.Find(request.VehicleId);
			if (vehicle == null || vehicle.IsDeleted == 1)
				throw new EntityNotFoundException("Vehicle");
			//If vehicle is rented renting won't be possible
			if (vehicle.Rented == true)
				throw new EntityExistsException();
			//If it's not rented, column in vehicle 'Rented' is changed to true until renting status is 'Returned'
			vehicle.Rented = true;
			vehicle.ModifiedAt = DateTime.Now;
			//
			rent.UserId = request.UserId;
			rent.CustomerId = request.CustomerId;
			rent.DropLocationId = request.DropLocationId;
			rent.LocationId = request.LocationId;
			rent.PickDate = request.PickDate;
			rent.DropDate = request.DropDate;
			rent.StatusId = statusId;
			rent.VehicleId = request.VehicleId;
			rent.FirstName = customer.FirstName;
			rent.LastName = customer.LastName;
			rent.Email = customer.Email;
			rent.VehicleCostPerDay = vehicle.CostPerDay;
			rent.PickAdress = pickLocaton.Adress;
			rent.DropAdress = dropLocation.Adress;
			//Starting calculatin of totall price based on days and vehicle cost per day
			//Price doesn't get lower for durations shorter than day. Price depenends strictly on number of days. 2 hrs = 1 day, 25 hrs = 2 days etc
			var days = Math.Ceiling((request.DropDate - request.PickDate).TotalDays);
			if (days <= 0)
				throw new ArgumentOutOfRangeException();
			//Getting integer of timespan between drop and pick up date
			rent.TotallPrice = vehicle.CostPerDay * days + pickLocaton.Price;
			//Adding rent to db
			AiContext.Rents.Add(rent);
			//Adding extra addons into db based on array of Extra Addon Ids
			foreach(var x in request.ExtraAddonIds)
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
				AiContext.RentExtraAddons.Add(extraAddonRent);
				rent.TotallPrice += extraAddonRent.Price;
			}
			//final calculation of price  based on days
			AiContext.SaveChanges();
			_emailSender.Body = "You have successfully made reservation";
			_emailSender.Subject = "Rent reservation";
			_emailSender.ToEmail = rent.Email;
			_emailSender.Send();
			return new RentResponseDTO
			{
				Id = rent.Id,
				UserId = rent.UserId,
				CustomerId = rent.CustomerId,
				LocationId = rent.LocationId,
				DropLocationId = rent.DropLocationId,
				VehicleId = rent.VehicleId,
				StatusId = rent.StatusId,
				VehicleModel = vehicle.Model,
				RentStatus = status.Name,
				VehicleCostPerDay = rent.VehicleCostPerDay,
				FirstName = rent.FirstName,
				LastName = rent.LastName,
				Email = rent.Email,
				TotallPrice = rent.TotallPrice,
				PickDate = rent.PickDate,
				DropDate = rent.DropDate,
				PickAdress = pickLocaton.Adress,
				DropAdress = dropLocation.Adress,
				RentExtraAddons = AiContext.RentExtraAddons
										.Where(re => re.RentId == rent.Id)
										.Select(re => new RentExtraAddonResponseDTO
										{
											ExtraAddonId = re.ExtraAddonId,
											ExtraAddonName = re.ExtraAddon.Name,
											Price = re.ExtraAddon.Price
										})
			};
			
		}
	}
}
