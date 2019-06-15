using BusinessLogic.Commands;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using BusinessLogic.Queries;
using BusinessLogic.Responses;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfGetFeaturesCommand : EfBaseCommand, IGetFeaturesCommand
    {
        public EfGetFeaturesCommand(EfContext context) : base(context)
        {
        }

        public Pagination<GetFeatureDto> Execute(FeatureQuery request)
        {
            var query = Context.Features.AsQueryable();

            if (request.Name != null)
                query = query.Where(f => f.Name.ToLower().Contains(request.Name.ToLower()));

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new Pagination<GetFeatureDto>
            {
                Total = totalCount,
                CurrentPage = request.PageNumber,
                Pages = pagesCount,
                Data = query.Select(f => new GetFeatureDto
                {
                    Name = f.Name
                })
            };
        }
    }
}
