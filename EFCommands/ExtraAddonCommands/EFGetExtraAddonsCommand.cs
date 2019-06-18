using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.ExtraAddonsCommands;
using Application.DTO.ResponseDTO;
using Application.Searches.ExtraAddonsSearches;
using EFDataAccess;

namespace EFCommands.ExtraAddonsCommands
{
    public class EFGetExtraAddonsCommand : BaseEFCommand, IGetExtraAddonsCommand
    {
        public EFGetExtraAddonsCommand(AIContext context) : base(context)
        {
        }

        public IEnumerable<ExtraAddonResponseDTO> Execute(ExtraAddonSearchName request)
        {
            var query = AiContext.ExtraAddons.AsQueryable().Where(x => x.IsDeleted == 0);
            var keyword = request.Keyword;
            if (keyword != null)
                query = query
                    .Where(x => x.Name.ToLower().Contains(keyword.ToLower()));
            return query
                .Select(x => new ExtraAddonResponseDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price
                });
        }
    }
}
