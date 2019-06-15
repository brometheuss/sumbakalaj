using BusinessLogic.Commands;
using BusinessLogic.Exceptions;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfDeleteModelCommand : EfBaseCommand, IDeleteModelCommand
    {
        public EfDeleteModelCommand(EfContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var model = Context.Models.Find(request);

            if (model == null)
                throw new EntityNotFoundException();

            Context.Models.Remove(model);
            Context.SaveChanges();
        }
    }
}
