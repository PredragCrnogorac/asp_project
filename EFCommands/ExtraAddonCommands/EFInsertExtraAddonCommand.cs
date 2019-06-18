using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.ExtraAddonsCommands;
using Application.DTO.RequestDTO;
using Application.DTO.ResponseDTO;
using Application.Exceptions;
using DataAccessModels;
using EFDataAccess;

namespace EFCommands.ExtraAddonCommands
{
    public class EFInsertExtraAddonCommand : BaseEFCommand, IInsertExtraAddonCommand
    {
        public EFInsertExtraAddonCommand(AIContext context) : base(context)
        {
        }

        public ExtraAddonResponseDTO Execute(ExtraAddonRequestDTO request)
        {
            var extra = new ExtraAddon();
            var existingExtra = AiContext.ExtraAddons.Where(x => x.Name == request.Name).Where(x => x.IsDeleted == 0).FirstOrDefault();
            if (existingExtra != null)
                throw new EntityExistsException("Extra add-on");
            extra.Name = request.Name;
            extra.Price = request.Price;
            AiContext.ExtraAddons.Add(extra);
            AiContext.SaveChanges();
            return new ExtraAddonResponseDTO
            {
                Id = extra.Id,
                Name = extra.Name,
                Price = extra.Price
            };
        }
    }
}
