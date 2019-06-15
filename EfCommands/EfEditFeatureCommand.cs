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
    public class EfEditFeatureCommand : EfBaseCommand, IEditFeatureCommand
    {
        public EfEditFeatureCommand(EfContext context) : base(context)
        {
        }

        public void Execute(AddFeatureDto request)
        {
            var feature = Context.Features.Find(request.Id);

            if (request.Name != feature.Name && Context.Features.Any(f => f.Name == request.Name))
                throw new EntityAlreadyExistsException();

            feature.Name = request.Name;
            Context.SaveChanges();
        }
    }
}
