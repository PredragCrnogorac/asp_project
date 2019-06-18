using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.VehicleTypeCommands;
using Application.DTO.ResponseDTO;
using Application.Searches;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;

namespace EFCommands.VehicleTypeCommands
{
    public class EFGetVehicleTypesCommand : BaseEFCommand, IGetVehicleTypesCommand
    {
        public EFGetVehicleTypesCommand(AIContext context) : base(context)
        {
        }

        public IEnumerable<VehicleTypeResponseDTO> Execute(VehicleTypeSearch request)
        {
            var keyword = request.Keyword;
            var query = AiContext.VehicleTypes
                .AsQueryable()
                .Where(x => x.IsDeleted == 0);
            if (keyword != null)
                query = query
                    .Where(x => x.Name.ToLower().Contains(keyword.ToLower()));
            return query
                .Include(x => x.Vehicles)
                .Select(x => new VehicleTypeResponseDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Vehicles = AiContext.Vehicles
                    .Where(v => v.VehicleTypeId == x.Id)
                    .Select(v => new VehicleTypeVehicleResponseDTO
                    {
                        Id = v.Id,
                        Model = v.Model,
                        CostPerHour = v.CostPerDay,
                        FuelTankCapacity = v.FuelTankCapacity,
                        VehicleBrand = v.Brand.Name,
						Automatic = v.Automatic,
						Rented = v.Rented,
                        Color = v.Color
                    })
                });
        }
    }
}
