using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.UserCommands;
using Application.Exceptions;
using EFDataAccess;

namespace EFCommands.UserCommands
{
    public class EFDeleteUserCommand : BaseEFCommand, IDeleteUserCommand
    {
        public EFDeleteUserCommand(AIContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var user = AiContext.Users.Find(request);
            if (user == null || user.IsDeleted == 1)
                throw new EntityNotFoundException("User");
            user.IsDeleted = 1;
            AiContext.SaveChanges();
        }
    }
}
