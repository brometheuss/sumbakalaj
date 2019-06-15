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
    public class EfGetUsersCommand : EfBaseCommand, IGetUsersCommand
    {
        public EfGetUsersCommand(EfContext context) : base(context)
        {
        }

        public Pagination<GetUserDto> Execute(UserQuery request)
        {
            var users = Context.Users.AsQueryable();

            if (request.FirstName != null)
                users = users.Where(u => u.FirstName.ToLower().Contains(request.FirstName.ToLower()));

            if (request.LastName != null)
                users = users.Where(u => u.LastName.ToLower().Contains(request.LastName.ToLower()));

            if (request.Email != null)
                users = users.Where(u => u.Email.ToLower().Contains(request.LastName.ToLower()));

            if (request.Username != null)
                users = users.Where(u => u.Username.ToLower().Contains(request.LastName.ToLower()));

            var total = users.Count();

            users = users.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)total / request.PerPage);

            return new Pagination<GetUserDto>
            {
                CurrentPage = request.PageNumber,
                Pages = pagesCount,
                Total = total,
                Data = users.Select(u => new GetUserDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Username = u.Username
                })
            };
        }
    }
}
