using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.RentCommands;
using Application.Exceptions;
using Application.Interfaces;
using EFDataAccess;

namespace EFCommands.RentCommands
{
	public class EFStartRentCommand : BaseEFCommand, IStartRentCommand
	{
		readonly IEmailSender _emailSender;
		public EFStartRentCommand(IEmailSender emailSender ,AIContext context) : base(context)
		{
			_emailSender = emailSender;
		}

		public void Execute(int request)
		{
			var rent = AiContext.Rents
				.Find(request);
			if (rent == null || rent.IsDeleted == 1)
				throw new EntityNotFoundException("Rent");
			//Only allowig if status is "Reserved"
			if (rent.StatusId != 9)
				throw new IndexOutOfRangeException();
			//In progress status, disabling modifying
			rent.StatusId = 10;
			rent.ModifiedAt = DateTime.Now;
			AiContext.SaveChanges();
			_emailSender.Body = "Your renting has started";
			_emailSender.Subject = "Rent reservation started";
			_emailSender.ToEmail = rent.Email;
			_emailSender.Send();
		}
	}
}
