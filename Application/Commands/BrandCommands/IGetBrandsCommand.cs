using Application.DTO.ResponseDTO;
using Application.Intefaces;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.BrandCommands
{
    public interface IGetBrandsCommand : ICommand<BrandSearch,IEnumerable<BrandResponseDTO>>
    {
    }
}
