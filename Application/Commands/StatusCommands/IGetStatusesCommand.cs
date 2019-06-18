using Application.DTO.ResponseDTO.StatusResponseDTO;
using Application.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.StatusCommands
{
	public interface IGetStatusesCommand : ICommand<object,IEnumerable<StatusResponseDTO>>
	{
	}
}
