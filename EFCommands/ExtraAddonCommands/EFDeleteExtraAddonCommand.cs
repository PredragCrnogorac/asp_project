using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.ExtraAddonsCommands;
using Application.Exceptions;
using EFDataAccess;

namespace EFCommands.ExtraAddonCommands
{
    public class EFDeleteExtraAddonCommand : BaseEFCommand, IDeleteExtraAddonCommand
    {
        public EFDeleteExtraAddonCommand(AIContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var extra = AiContext.ExtraAddons.Find(request);
            if (extra == null || extra.IsDeleted == 1)
                throw new EntityNotFoundException("Extra Add-on");
            extra.IsDeleted = 1;
            AiContext.SaveChanges();
        }
    }
}
