using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.CustomerCommands;
using Application.DTO.ResponseDTO;
using Application.Exceptions;
using EFDataAccess;

namespace EFCommands.CustomerCommands
{
	public class EFGetSingleCustomerCommand : BaseEFCommand, IGetSingleCustomerCommand
	{
		public EFGetSingleCustomerCommand(AIContext context) : base(context)
		{
		}

		public CustomerResponseDTO Execute(int request)
		{
			var customer = AiContext.Customers
				.Where(u => u.Id == request)
				.Where(u => u.IsDeleted == 0)
				.FirstOrDefault();
			if (customer == null)
				throw new EntityNotFoundException("Customer");
			return new CustomerResponseDTO
			{
				Id = customer.Id,
				FirstName = customer.FirstName,
				LastName = customer.LastName,
				Email = customer.Email,
				PhoneNumber = customer.PhoneNumber,
				Birthday = customer.Birthday
			};
		}
	}
}
