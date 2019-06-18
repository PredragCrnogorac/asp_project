using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.VehicleCommands;
using Application.DTO.RequestDTO;
using Application.DTO.ResponseDTO;
using Application.Exceptions;
using DataAccessModels;
using EFDataAccess;

namespace EFCommands.VehicleCommands
{
    public class EFInsertVehicleCommand : BaseEFCommand, IInsertVehicleCommand
    {
        public EFInsertVehicleCommand(AIContext context) : base(context)
        {
        }

        public VehicleResponseDTO Execute(VehicleRequestDTO request)
        {
            var vehicle = new Vehicle();
            var brand = AiContext.Brands
				.Find(request.BrandId);
            if (brand == null)
                throw new EntityNotFoundException("Brand");
            vehicle.BrandId = request.BrandId;
            var vehicleType = AiContext.VehicleTypes
				.Find(request.VehicleTypeId);
            if (vehicleType == null)
                throw new EntityNotFoundException("Vehicle type");
			vehicle.Automatic = request.Automatic.HasValue ? request.Automatic.Value : false;
			vehicle.VehicleTypeId = request.VehicleTypeId;
            vehicle.Model = request.Model;
            vehicle.CostPerDay = request.CostPerDay;
            vehicle.FuelTankCapacity = request.FuelTankCapacity;
            vehicle.Color = request.Color;
            AiContext.Vehicles.Add(vehicle);
            AiContext.SaveChanges();
			return new VehicleResponseDTO
			{
				Id = vehicle.Id,
				Model = vehicle.Model,
				CostPerDay = vehicle.CostPerDay,
				Color = vehicle.Color,
				FuelTankCapacity = vehicle.FuelTankCapacity,
				VehicleType = vehicle.VehicleType.Name,
				VehicleBrand = vehicle.Brand.Name,
				Automatic = vehicle.Automatic,
                Rented = vehicle.Rented
            };
        }
    }
}
