using Application.DTO.RequestDTO;
using Application.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.ExtraAddonsCommands
{
    public interface IUpdateExtraAddonCommand : IUpdate<int, ExtraAddonRequestDTO>
    {
    }
}
