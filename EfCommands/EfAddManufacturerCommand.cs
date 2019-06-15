using BusinessLogic.Commands;
using BusinessLogic.DTO;
using BusinessLogic.Exceptions;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfAddManufacturerCommand : EfBaseCommand, IAddManufacturerCommand
    {
        public EfAddManufacturerCommand(EfContext context) : base(context)
        {
        }

        public void Execute(AddManufacturerDto request)
        {
            if (Context.Manufacturers.Any(m => m.Name == request.Name))
                throw new EntityAlreadyExistsException();

            Context.Manufacturers.Add(new Manufacturer
            {
                Name = request.Name
            });

            Context.SaveChanges();
        }
    }
}
