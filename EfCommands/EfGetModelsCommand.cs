using BusinessLogic.Commands;
using BusinessLogic.DTO;
using BusinessLogic.Queries;
using BusinessLogic.Responses;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfGetModelsCommand : EfBaseCommand, IGetModelsCommand
    {
        public EfGetModelsCommand(EfContext context) : base(context)
        {
        }

        public Pagination<GetModelDto> Execute(ModelQuery request)
        {
            var query = Context.Models.AsQueryable();

            if (request.Name != null)
                query = query.Where(r => r.Name.ToLower().Contains(request.Name.ToLower()));

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new Pagination<GetModelDto>
            {
                CurrentPage = request.PageNumber,
                Pages = pagesCount,
                Total = totalCount,
                Data = query.Select(r => new GetModelDto
                {
                    Id = r.Id,
                    ManufacturerId = r.ManufacturerId,
                    Name = r.Name
                })
            };
        }
    }
}
