using BusinessLogic.Commands;
using BusinessLogic.DTO;
using BusinessLogic.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfGetFeatureCommand : EfBaseCommand, IGetFeatureCommand
    {
        public EfGetFeatureCommand(EfContext context) : base(context)
        {
        }

        public GetFeatureDto Execute(int request)
        {
            var feature = Context.Features.Find(request);

            if (feature == null)
                throw new EntityNotFoundException();

            return new GetFeatureDto
            {
                Name = feature.Name
            };
        }
    }
}
