using Application.DTO;
using Application.DTO.ResponseDTO;
using Application.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.UserCommands
{
    public interface IGetSingleUserCommand : ICommand<int, UserResponseDTO>
    {
    }
}
