using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.RoleCommands;
using Application.DTO;
using Application.DTO.RequestDTO;
using Application.Exceptions;
using EFDataAccess;

namespace EFCommands.RoleCommands
{
    public class EFUpdateRoleCommand : BaseEFCommand, IUpdateRoleCommand
    {
        public EFUpdateRoleCommand(AIContext context) : base(context)
        {
        }


        public void Execute(int id, RoleRequestDTO roleDTO)
        {
            
            var role = AiContext.Roles.Find(id);
            if (role == null || role.IsDeleted == 1)
                throw new EntityNotFoundException("Role");
			var roleExists = AiContext.Roles
				.Where(x => x.Name == roleDTO.Name)
				.Where(x => x.IsDeleted == 0)
				.FirstOrDefault();
			if (roleExists != null)
				throw new EntityExistsException("Role with that name");
			role.Name = roleDTO.Name;
            role.ModifiedAt = DateTime.UtcNow;
            AiContext.SaveChanges();

        }
    }
}
