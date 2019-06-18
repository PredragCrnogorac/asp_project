using Application.DTO.ResponseDTO.RentResponseDTO;
using Application.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.RentCommands
{
	public interface IGetSIngleRentCommand : ICommand<int, RentResponseDTO>
	{
	}
}
