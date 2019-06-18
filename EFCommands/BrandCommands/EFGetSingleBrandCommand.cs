using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.BrandCommands;
using Application.DTO.RequestDTO;
using Application.DTO.ResponseDTO;
using Application.Exceptions;
using EFDataAccess;

namespace EFCommands.BrandCommands
{
    public class EFGetSingleBrandCommand : BaseEFCommand, IGetSingleBrandCommand
    {
        public EFGetSingleBrandCommand(AIContext context) : base(context)
        {
        }

        public BrandResponseDTO Execute(int request)
        {
            var brand = AiContext.Brands.Find(request);
            if (brand == null || brand.IsDeleted == 1)
                throw new EntityNotFoundException("Brand");
			return new BrandResponseDTO
			{
				Id = brand.Id,
				Name = brand.Name,
				Vehicles = AiContext.Vehicles
				.Where(v => v.BrandId == brand.Id)
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
            };
        }

    }
}
