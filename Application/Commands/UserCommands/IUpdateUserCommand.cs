using Application.DTO;
using Application.DTO.RequestDTO;
using Application.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.UserCommands
{
    public interface IUpdateUserCommand : IUpdate<int, UserUpdateRequestDTO>
    {
    }
}
