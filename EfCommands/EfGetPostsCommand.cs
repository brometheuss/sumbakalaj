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
    public class EfGetPostsCommand : EfBaseCommand, IGetPostsCommand
    {
        public EfGetPostsCommand(EfContext context) : base(context)
        {
        }

        public Pagination<GetPostDto> Execute(PostQuery request)
        {
            var query = Context.Posts.AsQueryable();

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new Pagination<GetPostDto>
            {
                CurrentPage = request.PageNumber,
                Pages = pagesCount,
                Total = totalCount,
                Data = query.Select(p => new GetPostDto
                {
                    UserId = p.UserId,
                    ModelId = p.ModelId,
                    FuelId = p.FuelId
                })
            };
        }
    }
}
