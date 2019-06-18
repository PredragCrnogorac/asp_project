using Application.DTO.ResponseDTO;
using Application.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.CustomerCommands
{
	public interface IGetSingleCustomerCommand : ICommand<int, CustomerResponseDTO>
	{
	}
}
