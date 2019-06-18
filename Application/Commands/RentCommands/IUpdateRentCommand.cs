using Application.DTO.RequestDTO.RentRequestDTO;
using Application.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.RentCommands
{
	public interface IUpdateRentCommand : IUpdate<int, RentUpdateRequestDTO>
	{
	}
}
