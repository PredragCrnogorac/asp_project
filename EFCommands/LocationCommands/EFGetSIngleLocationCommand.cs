using Application.Commands.LocationCommands;
using Application.DTO.ResponseDTO;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.LocationCommands
{
	public class EFGetSIngleLocationCommand : BaseEFCommand, IGetSingleLocationCommand
	{
		public EFGetSIngleLocationCommand(AIContext context) : base(context)
		{
		}

		public LocationResponseDTO Execute(int request)
		{
			var location = AiContext.Locations
				.Find(request);
			if (location == null || location.IsDeleted == 1)
				throw new EntityNotFoundException("Location");
			return new LocationResponseDTO
			{
				Id = location.Id,
				Adress = location.Adress,
				Price = location.Price
			};
		}
	}
}
