using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.LocationCommands;
using Application.Exceptions;
using EFDataAccess;

namespace EFCommands.LocationCommands
{
	public class EFDeleteTransmissionCommand : BaseEFCommand, IDeleteLocationCommand
	{
		public EFDeleteTransmissionCommand(AIContext context) : base(context)
		{
		}

		public void Execute(int request)
		{
			var location = AiContext.Locations
				.Find(request);
			if (location == null || location.IsDeleted == 1)
				throw new EntityNotFoundException("Location");
			location.IsDeleted = 1;
			AiContext.SaveChanges();
		}
	}
}
