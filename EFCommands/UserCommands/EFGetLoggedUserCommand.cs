using System;
using System.Collections.Generic;
using System.Text;
using EFDataAccess;
using Application.Commands.UserCommands;
using Application.DTO.RequestDTO;
using Application.DTO.ResponseDTO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFCommands.UserCommands
{
	public class EFGetLoggedUserCommand : BaseEFCommand, IGetLoggedUser
	{
		public EFGetLoggedUserCommand(AIContext context) : base(context)
		{
		}

		public UserResponseDTO Execute(UserLogginDTO request)
		{
			var user = AiContext.Users.AsQueryable()
				.Include(x => x.Role)
				.Where(p => p.Username == request.Username)
				.Where(p => p.Password == request.Password)
				.FirstOrDefault();
			if (user != null)
				return new UserResponseDTO
				{
					Id = user.Id,
					FirstName = user.FirstName,
					LastName = user.LastName,
					Username = user.Username,
					RoleId = user.RoleId,
					RoleName = user.Role.Name,
					Password = user.Password
				};
			return null;
		}
	}
}
