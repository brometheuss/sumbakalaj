using BusinessLogic.Commands;
using BusinessLogic.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfDeleteFeatureCommand : EfBaseCommand, IDeleteFeatureCommand
    {
        public EfDeleteFeatureCommand(EfContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var feature = Context.Features.Find(request);

            if (feature == null)
                throw new EntityNotFoundException();

            Context.Features.Remove(feature);
            Context.SaveChanges();
        }
    }
}
