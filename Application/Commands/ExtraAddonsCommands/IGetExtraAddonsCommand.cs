using Application.DTO.ResponseDTO;
using Application.Intefaces;
using Application.Searches.ExtraAddonsSearches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.ExtraAddonsCommands
{
    public interface IGetExtraAddonsCommand : ICommand<ExtraAddonSearchName, IEnumerable<ExtraAddonResponseDTO>>
    {
    }
}
