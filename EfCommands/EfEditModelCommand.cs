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
    public class EfEditModelCommand : EfBaseCommand, IEditModelCommand
    {
        public EfEditModelCommand(EfContext context) : base(context)
        {
        }

        public void Execute(GetModelDto request)
        {
            var model = Context.Models.Find(request.Id);

            if (model == null)
                throw new EntityNotFoundException();

            if (request.Name != model.Name && Context.Models.Any(m => m.Name == request.Name))
                throw new EntityAlreadyExistsException();

            model.Name = request.Name;
            model.ManufacturerId = request.ManufacturerId;
            Context.SaveChanges();
        }
    }
}
