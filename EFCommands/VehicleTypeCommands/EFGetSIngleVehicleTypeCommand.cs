using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.VehicleTypeCommands;
using Application.DTO.ResponseDTO;
using Application.Exceptions;
using EFDataAccess;

namespace EFCommands.VehicleTypeCommands
{
    public class EFGetSIngleVehicleTypeCommand : BaseEFCommand, IGetSIngleVehicleTypeCommand
    {
        public EFGetSIngleVehicleTypeCommand(AIContext context) : base(context)
        {
        }

        public VehicleTypeResponseDTO Execute(int request)
        {
            var vehicleType = AiContext.VehicleTypes
                .Find(request);
            if (vehicleType == null || vehicleType.IsDeleted == 1)
                throw new EntityNotFoundException("Vehicle type");
            return new VehicleTypeResponseDTO
            {
                Id = vehicleType.Id,
                Name = vehicleType.Name,
                Vehicles = AiContext.Vehicles
                .Where(v => v.Id == vehicleType.Id)
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
            };
        }
    }
}
