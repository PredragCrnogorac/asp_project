using Application.DTO.RequestDTO;
using Application.DTO.ResponseDTO;
using Application.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.VehicleTypeCommands
{
    public interface IInsertVehicleTypeCommand : ICommand<VehicleTypeRequestDTO, VehicleTypeResponseDTO>
    {
    }
}
