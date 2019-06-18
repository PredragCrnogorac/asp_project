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
	public class EFInsertUserCommand : BaseEFCommand, IInsertUserCommand
	{
		public EFInsertUserCommand(AIContext context) : base(context)
		{
		}

		public UserDTO Execute(UserRequestDTO request)
		{
			var user = new User();
			var role = new Role();
			var username = AiContext.Users
				.Where(u => u.Username == request.Username)
				.FirstOrDefault();
			if (username != null && username.IsDeleted ==0)
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
			user.Password = request.Password;
			user.Role = role;
            AiContext.Users.Add(user);
            AiContext.SaveChanges();
            return new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
				Password = user.Password,
                RoleId = user.RoleId,
                RoleName = role.Name
            };
        }
    }
}
