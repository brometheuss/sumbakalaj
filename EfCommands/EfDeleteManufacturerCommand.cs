using BusinessLogic.Commands;
using BusinessLogic.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfDeleteManufacturerCommand : EfBaseCommand, IDeleteManufacturerCommand
    {
        public EfDeleteManufacturerCommand(EfContext context) : base(context)
        {
        }
        public void Execute(int request)
        {
            var manufacturer = Context.Manufacturers.Find(request);

            if (manufacturer == null)
                throw new EntityNotFoundException();

            Context.Manufacturers.Remove(manufacturer);
            Context.SaveChanges();
        }
    }
}
