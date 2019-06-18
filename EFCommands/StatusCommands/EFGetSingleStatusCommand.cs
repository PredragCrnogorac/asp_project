using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.StatusCommands;
using Application.DTO.ResponseDTO;
using Application.DTO.ResponseDTO.StatusResponseDTO;
using Application.Exceptions;
using EFDataAccess;

namespace EFCommands.StatusCommands
{
	public class EFGetSingleStatusCommand : BaseEFCommand, IGetSingleStatusCommand
	{
		public EFGetSingleStatusCommand(AIContext context) : base(context)
		{
		}

		public StatusResponseDTO Execute(int request)
		{
			var status = AiContext.RentStatus
				.Find(request);
			if (status == null || status.IsDeleted == 1)
				throw new EntityNotFoundException("Rent status");
			return new StatusResponseDTO
			{
				Id = status.Id,
				Name = status.Name,
				Rents = AiContext.Rents
								.Where(r => r.StatusId == status.Id)
								.Select(r => new StatusRentResponseDTO
								{
									Id = r.Id,
									UserId = r.UserId,
									CustomerId = r.CustomerId,
									LocationId = r.LocationId,
									DropLocationId = r.DropLocationId,
									VehicleId = r.VehicleId,
									VehicleModel = r.Vehicle.Model,
									VehicleCostPerDay = r.Vehicle.CostPerDay,
									FirstName = r.FirstName,
									LastName = r.LastName,
									Email = r.Email,
									TotallPrice = r.TotallPrice,
									PickDate = r.PickDate,
									DropDate = r.DropDate,
									PickAdress = r.PickAdress,
									DropAdress = r.DropAdress,
									RentExtraAddons = AiContext.RentExtraAddons
										.Where(re => re.RentId == r.Id)
										.Select(re => new RentExtraAddonResponseDTO
										{
											ExtraAddonId = re.ExtraAddonId,
											ExtraAddonName = re.ExtraAddon.Name,
											Price = re.ExtraAddon.Price
										})
								})
			};
		}
	}
}
