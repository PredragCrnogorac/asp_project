using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.VehicleCommands;
using Application.Exceptions;
using EFDataAccess;

namespace EFCommands.VehicleCommands
{
	public class EFDeleteVehicleCommand : BaseEFCommand, IDeleteVehicleCommand
	{
		public EFDeleteVehicleCommand(AIContext context) : base(context)
		{
		}

		public void Execute(int request)
		{
			var vehicle = AiContext.Vehicles
				.Find(request);
			if (vehicle == null || vehicle.IsDeleted == 1)
				throw new EntityNotFoundException("Vehicle");
			var rents = AiContext.Rents
				.Any(x => x.VehicleId == vehicle.Id);
			
			//disabling deleting vehicles which are being rented
			if (vehicle.Rented)
				throw new EntityExistsException();
			vehicle.IsDeleted = 1;
			AiContext.SaveChanges();
		}
	}
}
