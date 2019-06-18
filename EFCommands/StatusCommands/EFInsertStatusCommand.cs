using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.StatusCommands;
using Application.DTO.RequestDTO;
using Application.DTO.ResponseDTO.StatusResponseDTO;
using Application.Exceptions;
using DataAccessModels;
using EFDataAccess;

namespace EFCommands.StatusCommands
{
	public class EFInsertStatusCommand : BaseEFCommand, IInsertStatusCommand
	{
		public EFInsertStatusCommand(AIContext context) : base(context)
		{
		}

		public StatusResponseDTO Execute(StatusRequestDTO request)
		{
			var status = new RentStatus();
			var existingStatus = AiContext.RentStatus
				.Where(x => x.Name == request.Name)
				.Where(x => x.IsDeleted == 0)
				.FirstOrDefault();
			if (existingStatus != null)
				throw new EntityExistsException("Rent status");
			status.Name = request.Name;
			AiContext.RentStatus.Add(status);
			AiContext.SaveChanges();
			return new StatusResponseDTO
			{
				Id = status.Id,
				Name = status.Name
			};
		}
	}
}
