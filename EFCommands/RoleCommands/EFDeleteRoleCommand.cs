using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.RoleCommands;
using Application.Exceptions;
using EFDataAccess;

namespace EFCommands.RoleCommands
{
    public class EFDeleteRoleCommand : BaseEFCommand, IDeleteRoleCommand
    {
        public EFDeleteRoleCommand(AIContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var role = AiContext.Roles.Find(request);
            if (role == null || role.IsDeleted == 1)
                throw new EntityNotFoundException("Role");
			role.IsDeleted = 1;
            role.ModifiedAt = DateTime.UtcNow;
			var users = AiContext.Users
				.Where(u => u.RoleId == request);
			foreach (var user in users)
				user.RoleId = 8;
			AiContext.SaveChanges();
        }
    }
}
