using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.ExtraAddonsCommands;
using Application.DTO.RequestDTO;
using Application.Exceptions;
using DataAccessModels;
using EFDataAccess;

namespace EFCommands.ExtraAddonCommands
{
    public class EFUpdateExtraAddonCommand : BaseEFCommand, IUpdateExtraAddonCommand
    {
        public EFUpdateExtraAddonCommand(AIContext context) : base(context)
        {
        }

        public void Execute(int search, ExtraAddonRequestDTO request)
        {
            var extra = AiContext.ExtraAddons
				.Find(search);
            if (extra == null || extra.IsDeleted == 1)
                throw new EntityNotFoundException("Extra Add-on");
            var existingName = AiContext.ExtraAddons
				.Where(x => x.Name == request.Name)
				.Where(x => x.Id != extra.Id)
				.Where(x => x.IsDeleted == 0)
				.FirstOrDefault();
            if (existingName != null)
                throw new EntityExistsException("Extra Add-on");
            var extraUpdate = new ExtraAddon();
            extra.Name = request.Name;
            extra.Price = request.Price;
			extra.ModifiedAt = DateTime.Now;		
            AiContext.SaveChanges();
            
        }
    }
}
