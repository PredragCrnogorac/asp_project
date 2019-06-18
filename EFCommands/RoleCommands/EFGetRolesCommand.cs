using Application.Commands.RoleCommands;
using Application.DTO;
using Application.DTO.ResponseDTO;
using Application.Searches;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.RoleCommands
{
    public class EFGetRolesCommand : BaseEFCommand, IGetRoleCommand
    {
        public EFGetRolesCommand(AIContext context)
            :base(context)
        {

        }
        public IEnumerable<RoleResponseDTO> Execute(RoleSearch request)
        {
			var query = AiContext.Roles.AsQueryable()
				.Where(x => x.IsDeleted == 0);
            var keyword = request.Keyword;
            if(keyword != null)
            {
                query = query
                    .Where(r => r.Name.ToLower().Contains(keyword.ToLower()));
            }
            return query
                .Include(r => r.Users)
                .Select(r => new RoleResponseDTO
                {
                    Id = r.Id,
                    Name = r.Name,
                    Users = AiContext.Users
							.Where(u => u.IsDeleted == 0)
							.Where(u => u.RoleId == r.Id)
							.Select(u => new UserResponseDTO
							{
								Id = u.Id,
								FirstName = u.FirstName,
								LastName = u.LastName,
								Username = u.Username,
								RoleId = u.RoleId,
								RoleName = u.Role.Name
							})
                });

        }
    }
}
