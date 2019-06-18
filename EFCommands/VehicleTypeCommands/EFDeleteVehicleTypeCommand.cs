using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.VehicleTypeCommands;
using Application.Exceptions;
using EFDataAccess;

namespace EFCommands.VehicleTypeCommands
{
    public class EFDeleteVehicleTypeCommand : BaseEFCommand, IDeleteVehicleTypeCommand
    {
        public EFDeleteVehicleTypeCommand(AIContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var vehType = AiContext.VehicleTypes
                .Find(request);
            if (vehType == null || vehType.IsDeleted == 1)
                throw new EntityNotFoundException("Vehicle type");
            vehType.IsDeleted = 1;
            AiContext.SaveChanges();
        }
    }
}
