using Application.DTO;
using Application.DTO.ResponseDTO;
using Application.Intefaces;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.UserCommands
{
    public interface IGetUsersCommand : ICommand<UserSearch, IEnumerable<UserResponseDTO>>
    {
    }
}
