using Application.DTO.ResponseDTO;
using Application.Intefaces;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.LocationCommands
{
	public interface IGetLocationsCommand : ICommand<LocationSearch, IEnumerable<LocationResponseDTO>>
	{
	}
}
