using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.VehicleTypeCommands;
using Application.DTO.RequestDTO;
using Application.DTO.ResponseDTO;
using Application.Exceptions;
using DataAccessModels;
using EFDataAccess;

namespace EFCommands.VehicleTypeCommands
{
    public class EFInsertVehicleTypeCommand : BaseEFCommand, IInsertVehicleTypeCommand
    {
        public EFInsertVehicleTypeCommand(AIContext context) : base(context)
        {
        }

        public VehicleTypeResponseDTO Execute(VehicleTypeRequestDTO request)
        {
            var vehType = new VehicleType();
            var existingVehType = AiContext.VehicleTypes
                .Where(x => x.Name == request.Name)
                .Where(x => x.IsDeleted == 0)
                .FirstOrDefault();
            if (existingVehType != null)
                throw new EntityExistsException("Vehicle type");
            vehType.Name = request.Name;
            AiContext.VehicleTypes
                .Add(vehType);
            AiContext.SaveChanges();
            return new VehicleTypeResponseDTO
            {
                Id = vehType.Id,
                Name = vehType.Name
            };
        }
    }
}
