using Application.DTO.RequestDTO;
using Application.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.LocationCommands
{
	public interface IUpdateLocationCommand : IUpdate<int, LocationRequestDTO>
	{
	}
}
