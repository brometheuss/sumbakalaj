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
    public class EfGetRolesCommand : EfBaseCommand, IGetRolesCommand
    {
        public EfGetRolesCommand(EfContext context) : base(context)
        {
        }

        public Pagination<GetRoleDto> Execute(RoleQuery request)
        {
            var query = Context.Roles.AsQueryable();

            if (request.Name != null)
                query = query.Where(r => r.Name.ToLower().Contains(request.Name.ToLower()));

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new Pagination<GetRoleDto>
            {
                CurrentPage = request.PageNumber,
                Pages = pagesCount,
                Total = totalCount,
                Data = query.Select(r => new GetRoleDto
                {
                    Name = r.Name
                })
            };
        }
    }
}
