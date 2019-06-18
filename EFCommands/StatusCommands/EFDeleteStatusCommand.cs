using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.StatusCommands;
using Application.Exceptions;
using EFDataAccess;

namespace EFCommands.StatusCommands
{
	public class EFDeleteStatusCommand : BaseEFCommand, IDeleteStatusCommand
	{
		public EFDeleteStatusCommand(AIContext context) : base(context)
		{
		}

		public void Execute(int request)
		{
			var status = AiContext.RentStatus
				.Find(request);
			if (status == null || status.IsDeleted == 1)
				throw new EntityNotFoundException("Rent status");
			var statuses = AiContext.Rents
				.Where(x => x.IsDeleted == 0)
				.Where(x => x.StatusId == request)
				.AsQueryable();
			if (statuses.Any())
				throw new EntityExistsException();
			status.IsDeleted = 1;
			AiContext.SaveChanges();
		}
	}
}
