using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.ExtraAddonsCommands;
using Application.DTO.ResponseDTO;
using Application.Exceptions;
using EFDataAccess;

namespace EFCommands.ExtraAddonCommands
{
    public class EFGetSingleExtraAddonCommand : BaseEFCommand, IGetSingleExtraAddonCommand
    {
        public EFGetSingleExtraAddonCommand(AIContext context) : base(context)
        {
        }

        public ExtraAddonResponseDTO Execute(int request)
        {
            var extra = AiContext.ExtraAddons.Find(request);
            if (extra == null || extra.IsDeleted == 1)
                throw new EntityNotFoundException("Extra add-on");
            return new ExtraAddonResponseDTO
            {
                Id = extra.Id,
                Name = extra.Name,
                Price = extra.Price
            };
        }
    }
}
