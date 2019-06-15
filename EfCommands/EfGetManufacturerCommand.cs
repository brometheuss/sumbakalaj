using BusinessLogic.Commands;
using BusinessLogic.DTO;
using BusinessLogic.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfGetManufacturerCommand : EfBaseCommand, IGetManufacturerCommand
    {
        public EfGetManufacturerCommand(EfContext context) : base(context)
        {
        }

        public GetManufacturerDto Execute(int request)
        {
            var manufacturer = Context.Manufacturers.Find(request);

            if (manufacturer == null)
                throw new EntityNotFoundException();

            return new GetManufacturerDto
            {
                Id = manufacturer.Id,
                Name = manufacturer.Name
            };
        }
    }
}
