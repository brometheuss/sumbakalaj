using BusinessLogic.Commands;
using BusinessLogic.DTO;
using BusinessLogic.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfEditManufacturerCommand : EfBaseCommand, IEditManufacturerCommand
    {
        public EfEditManufacturerCommand(EfContext context) : base(context)
        {
        }

        public void Execute(AddManufacturerDto request)
        {
            var manufacturer = Context.Manufacturers.Find(request.Id);

            if (manufacturer == null)
                throw new EntityNotFoundException();

            if (request.Name != manufacturer.Name && Context.Manufacturers.Any(m => m.Name == request.Name))
                throw new EntityAlreadyExistsException();

            manufacturer.Name = request.Name;
            Context.SaveChanges();
        }
    }
}
