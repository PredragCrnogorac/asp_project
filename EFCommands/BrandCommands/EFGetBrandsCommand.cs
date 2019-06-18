using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.BrandCommands;
using Application.DTO.ResponseDTO;
using Application.Searches;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;

namespace EFCommands.BrandCommands
{
    public class EFGetBrandsCommand : BaseEFCommand, IGetBrandsCommand
    {
        public EFGetBrandsCommand(AIContext context) : base(context)
        {
        }

        public IEnumerable<BrandResponseDTO> Execute(BrandSearch request)
        {
            var keyword = request.Keyword;
            var query = AiContext.Brands
                .AsQueryable()
                .Where(x => x.IsDeleted == 0);
            if (keyword != null)
                query = query
                    .Where(x => x.Name.ToLower().Contains(keyword.ToLower()));
            return query
                .Include(u => u.Vehicles)
                .Select(x => new BrandResponseDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Vehicles = AiContext.Vehicles
                    .Where(v => v.BrandId == x.Id)
                    .Select(v => new BrandVehicleResponseDTO
                    {
                        Id = v.Id,
                        Model = v.Model,
                        CostPerHour = v.CostPerDay,
                        FuelTankCapacity = v.FuelTankCapacity,
                        VehicleType = v.VehicleType.Name,
						Automatic = v.Automatic,
                        Rented = v.Rented,
                        Color = v.Color
                    })
                });
        }
    }
}
