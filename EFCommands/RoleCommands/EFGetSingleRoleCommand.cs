using Application.Commands.RoleCommands;
using Application.DTO;
using Application.DTO.ResponseDTO;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.RoleCommands
{
    public class EFGetSingleRoleCommand : BaseEFCommand, IGetSingleRoleCommand
    {
        public EFGetSingleRoleCommand(AIContext context) : base(context)
        {
        }

        public RoleResponseDTO Execute(int request)
        {
            var id = request;
            var role = AiContext
                .Roles
                .Find(id);
            if (role == null || role.IsDeleted == 1)
                throw new  EntityNotFoundException("Role");
           
            return new RoleResponseDTO
            {
                Id = role.Id,
                Name = role.Name,
				Users = AiContext.Users
							.Where(u => u.IsDeleted == 0)
							.Where(u => u.RoleId == request)
							.Select(u => new UserResponseDTO
							{
								Id = u.Id,
								FirstName = u.FirstName,
								LastName = u.LastName,
								Username = u.Username,
								RoleId = u.RoleId,
								RoleName = u.Role.Name
							})
			};
                
        }
    }
}
