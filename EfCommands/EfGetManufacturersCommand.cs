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
    public class EfGetManufacturersCommand : EfBaseCommand, IGetManufacturersCommand
    {
        public EfGetManufacturersCommand(EfContext context) : base(context)
        {
        }

        public Pagination<GetManufacturerDto> Execute(ManufacturerQuery request)
        {
            var query = Context.Manufacturers.AsQueryable();

            if (request.Name != null)
                query = query.Where(r => r.Name.ToLower().Contains(request.Name.ToLower()));

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new Pagination<GetManufacturerDto>
            {
                CurrentPage = request.PageNumber,
                Pages = pagesCount,
                Total = totalCount,
                Data = query.Select(r => new GetManufacturerDto
                {
                    Name = r.Name
                })
            };
        }
    }
}
