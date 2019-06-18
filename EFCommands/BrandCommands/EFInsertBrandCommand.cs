using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.BrandCommands;
using Application.DTO.RequestDTO;
using Application.DTO.ResponseDTO;
using Application.Exceptions;
using DataAccessModels;
using EFDataAccess;

namespace EFCommands.BrandCommands
{
    public class EFInsertBrandCommand : BaseEFCommand, IInsertBrandCommand
    {
        public EFInsertBrandCommand(AIContext context) : base(context)
        {
        }

        public BrandResponseDTO Execute(BrandRequestDTO request)
        {
            var brand = new Brand();
            var existingBrand = AiContext.Brands.Where(x => x.Name == request.Name).Where(x => x.IsDeleted == 0).FirstOrDefault();
            if (existingBrand != null)
                throw new EntityExistsException("Brand");
            brand.Name = request.Name;
            AiContext.Brands.Add(brand);
            AiContext.SaveChanges();
            return new BrandResponseDTO
            {
                Id = brand.Id,
                Name = brand.Name
            };
        }
    }
}
