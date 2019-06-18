using Application.DTO.ResponseDTO;
using Application.Intefaces;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.VehicleTypeCommands
{
    public interface IGetVehicleTypesCommand : ICommand<VehicleTypeSearch, IEnumerable<VehicleTypeResponseDTO>>
    {
    }
}
