using Application.DTO.RequestDTO;
using Application.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.StatusCommands
{
	public interface IUpdateStatusCommand : IUpdate<int, StatusRequestDTO>
	{
	}
}
