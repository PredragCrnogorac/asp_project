using Application.DTO.RequestDTO;
using Application.DTO.ResponseDTO;
using Application.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.VehicleCommands
{
    public interface IInsertVehicleCommand : ICommand<VehicleRequestDTO, VehicleResponseDTO>
    {
    }
}
