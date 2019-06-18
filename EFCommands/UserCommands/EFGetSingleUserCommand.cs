using Application.Commands.UserCommands;
using Application.DTO;
using Application.DTO.ResponseDTO;
using Application.Exceptions;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.UserCommands
{
    public class EFGetSingleUserCommand : BaseEFCommand, IGetSingleUserCommand
    {

        public EFGetSingleUserCommand(AIContext context) : base(context)
        {
        }

        public UserResponseDTO Execute(int request)
        {
            var user = AiContext.Users
				.Include(u => u.Role)
				.Where(u => u.Id == request)
				.Where(u => u.IsDeleted == 0)
				.FirstOrDefault();
            if (user == null)
                throw new EntityNotFoundException("User");
            return new UserResponseDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                RoleId = user.RoleId,
                RoleName = user.Role.Name
            };
        }
    }
}
