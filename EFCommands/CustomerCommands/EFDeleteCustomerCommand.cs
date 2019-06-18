using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.CustomerCommands;
using Application.Exceptions;
using EFDataAccess;

namespace EFCommands.CustomerCommands
{
	public class EFDeleteCustomerCommand : BaseEFCommand, IDeleteCustomerCommand
	{
		public EFDeleteCustomerCommand(AIContext context) : base(context)
		{
		}

		public void Execute(int request)
		{
			var user = AiContext.Customers.Find(request);
			if (user == null || user.IsDeleted == 1)
				throw new EntityNotFoundException("Customer");
			user.IsDeleted = 1;
			AiContext.SaveChanges();
		}
	}
}
