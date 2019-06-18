using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.RentCommands;
using Application.Exceptions;
using EFDataAccess;

namespace EFCommands.RentCommands
{
	public class EFDeleteRentCommand : BaseEFCommand, IDeleteRentCommand
	{
		public EFDeleteRentCommand(AIContext context) : base(context)
		{
		}

		public void Execute(int request)
		{
			var rent = AiContext.Rents
				.Find(request);
			if (rent == null || rent.IsDeleted == 1)
				throw new EntityNotFoundException("Rent");
			if (rent.StatusId == 10)
				throw new EntityExistsException();
			var extraAddonRents = AiContext.RentExtraAddons
				.Where(x => x.RentId == request);
			foreach (var x in extraAddonRents)
				x.IsDeleted = 1;
			rent.IsDeleted = 1;
			rent.ModifiedAt = DateTime.Now;
			AiContext.SaveChanges();
		}
	}
}
