using BusinessLogic.Commands;
using BusinessLogic.DTO;
using BusinessLogic.Queries;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfGetPostFeaturesCommand : EfBaseCommand, IGetPostFeaturesCommand

    {
        public EfGetPostFeaturesCommand(EfContext context) : base(context)
        {
        }
         
        public IEnumerable<GetPostFeatureDto> Execute(FeatureQuery query)
        { 
                return Context.Posts.Include(pf => pf.PostFeatures)
                .ThenInclude(p => p.Post).AsQueryable()
                .Select(pf => new GetPostFeatureDto
                {
                    Id = pf.Id,
                    FuelId = pf.FuelId,
                    ModelId = pf.ModelId,
                    Name = pf.PostFeatures.Select(f => f.Feature.Name).ToString(),
                    UserId = pf.UserId
                });
        }
    }
}
