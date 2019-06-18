using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.CustomerCommands;
using Application.DTO.RequestDTO;
using Application.Exceptions;
using EFDataAccess;

namespace EFCommands.CustomerCommands
{
	public class EFUpdateCustomerCommand : BaseEFCommand, IUpdateCustomerCommand
	{
		public EFUpdateCustomerCommand(AIContext context) : base(context)
		{
		}

		public void Execute(int search, CustomerRequestDTO request)
		{
			var customer = AiContext.Customers.Find(search);
			if (customer == null || customer.IsDeleted == 1)
				throw new EntityNotFoundException("Customer");
			customer.FirstName = request.FirstName;
			customer.LastName = request.LastName;
			customer.Email = request.Email;
			customer.PhoneNumber = request.PhoneNumber;
			customer.Birthday = request.Birthday;
			customer.ModifiedAt = DateTime.Now;
			AiContext.SaveChanges();
		}
	}
}
