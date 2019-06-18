using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.BrandCommands;
using Application.DTO.RequestDTO;
using Application.Exceptions;
using EFDataAccess;

namespace EFCommands.BrandCommands
{
    public class EFUpdateBrandCommand : BaseEFCommand, IUpdateBrandCommand
    {
        public EFUpdateBrandCommand(AIContext context) : base(context)
        {
        }

        public void Execute(int search, BrandRequestDTO request)
        {
            var brand = AiContext.Brands.Find(search);
            if (brand == null || brand.IsDeleted == 1)
                throw new EntityNotFoundException("Brand");
            var brandExists = AiContext.Brands
                .Where(x => x.Name == request.Name)
                .Where(x => x.Id != brand.Id)
                .Where(x => x.IsDeleted == 0)
                .FirstOrDefault();
            if (brandExists != null)
                throw new EntityExistsException("Brand");
            brand.Name = request.Name;
			brand.ModifiedAt = DateTime.Now;
            AiContext.SaveChanges();
        }
    }
}
