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
    public class EfAddModelCommand : EfBaseCommand, IAddModelCommand
    {
        public EfAddModelCommand(EfContext context) : base(context)
        {
        }

        public void Execute(AddModelDto request)
        {
            if (Context.Models.Any(m => m.Name == request.Name))
                throw new EntityAlreadyExistsException();

            Context.Models.Add(new Model
            {
                ManufacturerId = request.ManufacturerId,
                Name = request.Name
            });
            Context.SaveChanges();
        }
    }
}
