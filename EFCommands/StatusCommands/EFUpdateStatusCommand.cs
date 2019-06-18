using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.StatusCommands;
using Application.DTO.RequestDTO;
using Application.Exceptions;
using EFDataAccess;

namespace EFCommands.StatusCommands
{
	public class EFUpdateStatusCommand : BaseEFCommand, IUpdateStatusCommand
	{
		public EFUpdateStatusCommand(AIContext context) : base(context)
		{
		}

		public void Execute(int search, StatusRequestDTO request)
		{
			var status = AiContext.RentStatus
				.Find(search);
			if (status == null || status.IsDeleted == 1)
				throw new EntityNotFoundException("Rent status");
			var existingStatus = AiContext.RentStatus
				.Where(x => x.Name == request.Name)
				.Where(x => x.IsDeleted == 0)
				.FirstOrDefault();
			if (existingStatus != null)
				throw new EntityExistsException("Rent status");
			status.Name = request.Name;
			status.ModifiedAt = DateTime.Now;
			AiContext.SaveChanges();
		}
	}
}
