using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.RentCommands;
using Application.Exceptions;
using Application.Interfaces;
using EFDataAccess;

namespace EFCommands.RentCommands
{
	public class EFFinishRentCommand : BaseEFCommand, IFinishRentCommand
	{
		readonly IEmailSender _emailSender;
		public EFFinishRentCommand(AIContext context, IEmailSender emailSender) : base(context)
		{
			_emailSender = emailSender;
		}

		public void Execute(int request)
		{
			var rent = AiContext.Rents
				.Find(request);
			if (rent == null || rent.IsDeleted == 1)
				throw new EntityNotFoundException("Rent");
			//Only rents in progress can be stopped
			if (rent.StatusId != 10)
				throw new IndexOutOfRangeException();
			var vehicle = AiContext.Vehicles
				.Find(rent.VehicleId);
			vehicle.Rented = false;
			vehicle.ModifiedAt = DateTime.Now;
			rent.StatusId = 11;
			rent.ModifiedAt = DateTime.Now;
			AiContext.SaveChanges();
			_emailSender.Body = "Your rent has ended, thank you for using our service!";
			_emailSender.Subject = "Rent reservation";
			_emailSender.ToEmail = rent.Email;
			_emailSender.Send();
		}
	}
}
