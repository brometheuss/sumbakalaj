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
    public class EfAddFeatureCommand : EfBaseCommand, IAddFeatureCommand
    {
        public EfAddFeatureCommand(EfContext context) : base(context)
        {
        }

        public void Execute(AddFeatureDto request)
        {
            if (Context.Features.Any(f => f.Name == request.Name))
                throw new EntityAlreadyExistsException();

            Context.Features.Add(new Feature
            {
                Name = request.Name
            });

            Context.SaveChanges();
        }
    }
}
