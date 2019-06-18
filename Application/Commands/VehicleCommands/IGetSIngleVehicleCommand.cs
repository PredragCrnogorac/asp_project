using Application.DTO.ResponseDTO;
using Application.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.VehicleCommands
{
	public interface IGetSIngleVehicleCommand : ICommand<int, VehicleResponseDTO>
	{
	}
}
