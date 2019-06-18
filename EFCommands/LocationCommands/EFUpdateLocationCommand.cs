using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.LocationCommands;
using Application.DTO.RequestDTO;
using Application.Exceptions;
using EFDataAccess;

namespace EFCommands.LocationCommands
{
	public class EFUpdateLocationCommand : BaseEFCommand, IUpdateLocationCommand
	{
		public EFUpdateLocationCommand(AIContext context) : base(context)
		{
		}

		public void Execute(int search, LocationRequestDTO request)
		{
			var location = AiContext.Locations
				.Find(search);
			if (location == null || location.IsDeleted == 1)
				throw new EntityNotFoundException("Location");
			var existingLocation = AiContext.Locations
				.Where(x => x.Adress == request.Adress)
				.Where(x => x.IsDeleted == 0)
				.Where(x => x.Id != location.Id)
				.FirstOrDefault();
			if (existingLocation != null)
				throw new EntityExistsException("Location");
			location.Adress = request.Adress;
			location.Price = request.Price;
			location.ModifiedAt = DateTime.UtcNow;
			AiContext.SaveChanges();
		}
	}
}
