using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.RentCommands;
using Application.DTO.ResponseDTO;
using Application.DTO.ResponseDTO.RentResponseDTO;
using Application.Exceptions;
using EFDataAccess;

namespace EFCommands.RentCommands
{
	public class EFGetSingleRentCommand : BaseEFCommand, IGetSIngleRentCommand
	{
		public EFGetSingleRentCommand(AIContext context) : base(context)
		{
		}

		public RentResponseDTO Execute(int request)
		{
			var rent = AiContext.Rents
				.Find(request);
			if (rent == null || rent.IsDeleted == 1)
				throw new EntityNotFoundException("Rent");
			var vehicleModel = AiContext.Vehicles
				.Where(x => x.Id == rent.VehicleId)
				.FirstOrDefault();
			var rentStatus = AiContext.RentStatus
				.Where(x => x.Id == rent.StatusId)
				.FirstOrDefault();

			return new RentResponseDTO
			{
				Id = rent.Id,
				UserId = rent.UserId,
				CustomerId = rent.CustomerId,
				LocationId = rent.LocationId,
				DropLocationId = rent.DropLocationId,
				VehicleId = rent.VehicleId,
				StatusId = rent.StatusId,
				VehicleModel = vehicleModel.Model,
				RentStatus = rentStatus.Name,
				VehicleCostPerDay = rent.VehicleCostPerDay,
				FirstName = rent.FirstName,
				LastName = rent.LastName,
				Email = rent.Email,
				TotallPrice = rent.TotallPrice,
				PickDate = rent.PickDate,
				DropDate = rent.DropDate,
				PickAdress = rent.PickAdress,
				DropAdress = rent.DropAdress,
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
