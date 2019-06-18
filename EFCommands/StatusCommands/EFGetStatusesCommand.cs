using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.StatusCommands;
using Application.DTO.ResponseDTO;
using Application.DTO.ResponseDTO.StatusResponseDTO;
using EFDataAccess;

namespace EFCommands.StatusCommands
{
	public class EFGetStatusesCommand : BaseEFCommand, IGetStatusesCommand
	{
		public EFGetStatusesCommand(AIContext context) : base(context)
		{
		}

		public IEnumerable<StatusResponseDTO> Execute(object request)
		{
			//Not doing search because there will be just 3 statuses, rarely changed
			var query = AiContext.RentStatus
				.Where(x => x.IsDeleted == 0)
				.AsQueryable();
			return query
				.Select(x => new StatusResponseDTO
				{
					Id = x.Id,
					Name = x.Name,
					Rents = AiContext.Rents
								.Where(r => r.StatusId == x.Id)
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
				});
		}
	}
}
