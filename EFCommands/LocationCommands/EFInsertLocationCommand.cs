using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.LocationCommands;
using Application.DTO.RequestDTO;
using Application.DTO.ResponseDTO;
using Application.Exceptions;
using DataAccessModels;
using EFDataAccess;

namespace EFCommands.LocationCommands
{
	public class EFInsertLocationCommand : BaseEFCommand, IInsertLocationCommand
	{
		public EFInsertLocationCommand(AIContext context) : base(context)
		{
		}

		public LocationResponseDTO Execute(LocationRequestDTO request)
		{
			var location = new Location();
			var existingLocation = AiContext.Locations
				.Where(x => x.Adress == request.Adress)
				.Where(x => x.IsDeleted == 0)
				.FirstOrDefault();
			if (existingLocation != null)
				throw new EntityExistsException("Location");
			location.Adress = request.Adress;
			location.Price = request.Price;
			AiContext.Add(location);
			AiContext.SaveChanges();
			return new LocationResponseDTO
			{
				Id = location.Id,
				Adress = location.Adress,
				Price = location.Price
			};
		}
	}
}
