using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.UserCommands;
using Application.DTO;
using Application.DTO.RequestDTO;
using Application.Exceptions;
using DataAccessModels;
using EFDataAccess;

namespace EFCommands.UserCommands
{
    public class EFUpdateUserCommand : BaseEFCommand, IUpdateUserCommand
    {
        public EFUpdateUserCommand(AIContext context) : base(context)
        {
        }

        public void Execute(int search, UserUpdateRequestDTO request)
        {
            var role = new Role();
            var username = AiContext.Users
				.Where(u => u.Username == request.Username)
				.Where(u => u.IsDeleted == 0)
				.Where(u => u.Id != search)
				.FirstOrDefault();
            var user = AiContext.Users
				.Where(u => u.Id == search)
				.Where(u => u.IsDeleted == 0)
				.FirstOrDefault();
            if (user == null)
                throw new EntityNotFoundException("User");
            if (username != null)
                throw new EntityExistsException("User with that username");
			int roleId = request.RoleId.HasValue ? request.RoleId.GetValueOrDefault() : 8;
			role = AiContext.Roles
				.Where(x => x.Id == roleId)
				.Where(x => x.IsDeleted == 0)
				.FirstOrDefault();
			if (role == null)
				throw new EntityNotFoundException("Role");
			user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Username = request.Username;
			user.RoleId = roleId;
			user.ModifiedAt = DateTime.Now;
            AiContext.SaveChanges();
            
        }
    }
}
