using Application.DTO.ResponseDTO;
using Application.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.ExtraAddonsCommands
{
    public interface IGetSingleExtraAddonCommand : ICommand<int, ExtraAddonResponseDTO>
    {
    }
}
