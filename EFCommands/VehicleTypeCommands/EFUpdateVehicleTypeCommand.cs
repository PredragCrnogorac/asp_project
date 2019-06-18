using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.VehicleTypeCommands;
using Application.DTO.RequestDTO;
using Application.Exceptions;
using EFDataAccess;

namespace EFCommands.VehicleTypeCommands
{
    public class EFUpdateVehicleTypeCommand : BaseEFCommand, IUpdateVehicleTypeCommand
    {
        public EFUpdateVehicleTypeCommand(AIContext context) : base(context)
        {
        }

        public void Execute(int search, VehicleTypeRequestDTO request)
        {
            var vehType = AiContext.VehicleTypes
                .Find(search);
            if (vehType == null || vehType.IsDeleted == 1)
                throw new EntityNotFoundException("Vehicle type");
            var existingVehType = AiContext.VehicleTypes
                .Where(x => x.Id != vehType.Id)
                .Where(x => x.Name == request.Name)
                .Where(x => x.IsDeleted == 0)
                .FirstOrDefault();
            if (existingVehType != null)
                throw new EntityExistsException("Vehicle type");
            vehType.Name = request.Name;
			vehType.ModifiedAt = DateTime.Now;
			AiContext.SaveChanges();
        }
    }
}
