using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.VehicleCommands;
using Application.DTO.RequestDTO;
using Application.Exceptions;
using EFDataAccess;

namespace EFCommands.VehicleCommands
{
	public class EFUpdateVehicleCommand : BaseEFCommand, IUpdateVehicleCommand
	{
		public EFUpdateVehicleCommand(AIContext context) : base(context)
		{
		}

		public void Execute(int search, VehicleRequestDTO request)
		{
			var vehicle = AiContext.Vehicles
				.Find(search);
			if (vehicle == null || vehicle.IsDeleted == 1)
				throw new EntityNotFoundException("Vehicle");
			var existingBrand = AiContext.Brands
				.Find(request.BrandId);
			if (existingBrand == null)
				throw new EntityNotFoundException("Brand");
			var existingVehType = AiContext.VehicleTypes
				.Find(request.VehicleTypeId);
			if (existingVehType == null)
				throw new EntityNotFoundException("Vehicle type");
			vehicle.Automatic = request.Automatic.HasValue ? request.Automatic.Value : false;
			vehicle.Model = request.Model;
			vehicle.CostPerDay = request.CostPerDay;
			vehicle.BrandId = request.BrandId;
			vehicle.VehicleTypeId = request.VehicleTypeId;
			vehicle.FuelTankCapacity = request.FuelTankCapacity;
			vehicle.Color = request.Color;
			vehicle.ModifiedAt = DateTime.Now;
			AiContext.SaveChanges();
		}
	}
}
