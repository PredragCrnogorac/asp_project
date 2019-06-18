using Application.DTO.ResponseDTO;
using Application.Intefaces;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.CustomerCommands
{
	public interface IGetCustomersCommand : ICommand<CustomerSearch, IEnumerable<CustomerResponseDTO>>
	{
	}
}
