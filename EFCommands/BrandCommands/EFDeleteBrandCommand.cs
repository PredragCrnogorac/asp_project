using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.BrandCommands;
using Application.Exceptions;
using EFDataAccess;

namespace EFCommands.BrandCommands
{
    public class EFDeleteBrandCommand : BaseEFCommand, IDeleteBrandCommand
    {
        public EFDeleteBrandCommand(AIContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var brand = AiContext.Brands.Find(request);
            if (brand == null || brand.IsDeleted == 1)
                throw new EntityNotFoundException("Brand");
            brand.IsDeleted = 1;
            AiContext.SaveChanges();
        }
    }
}
