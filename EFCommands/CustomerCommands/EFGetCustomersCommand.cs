using Application.Commands.CustomerCommands;
using Application.DTO.ResponseDTO;
using Application.Searches;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.CustomerCommands
{
	public class EFGetCustomersCommand : BaseEFCommand, IGetCustomersCommand
	{
		public EFGetCustomersCommand(AIContext context) : base(context)
		{
		}

		public IEnumerable<CustomerResponseDTO> Execute(CustomerSearch request)
		{
			var query = AiContext.Customers
				.AsQueryable()
				.Where(u => u.IsDeleted == 0);
			var keyword = request.Keyword;
			if (keyword != null)
				query = query
					.Where(u => u.Email.ToLower().Contains(keyword.ToLower()));
			return query
				.Select(u => new CustomerResponseDTO
				{
					Id = u.Id,
					FirstName = u.FirstName,
					LastName = u.LastName,
					Email = u.Email,
					PhoneNumber = u.PhoneNumber,
					Birthday = u.Birthday
				});
		}
	}
}
