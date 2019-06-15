using BusinessLogic.Commands;
using BusinessLogic.DTO;
using BusinessLogic.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfGetModelCommand : EfBaseCommand, IGetModelCommand
    {
        public EfGetModelCommand(EfContext context) : base(context)
        {
        }

        public GetModelDto Execute(int request)
        {
            var model = Context.Models.Find(request);

            if (model == null)
                throw new EntityNotFoundException();

            return new GetModelDto
            {
                Id = model.Id,
                Name = model.Name,
                ManufacturerId = model.ManufacturerId
            };
        }
    }
}
