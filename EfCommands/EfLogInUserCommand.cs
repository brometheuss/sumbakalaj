using Api.Helpers;
using BusinessLogic.Commands;
using BusinessLogic.DTO;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfLogInUserCommand : EfBaseCommand, ILogInUserCommand
    {
        public EfLogInUserCommand(EfContext context) : base(context)
        {
        }

        public LoggedUser Execute(LogUser request)
        {
            var user = Context.Users.Include(u => u.Role).Where(u => u.Username == request.Username && u.Password == request.Password).FirstOrDefault();

            if (user == null)
                throw new Exception("Invalid username or password");

            return new LoggedUser
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Role = user.Role.Name
            };
        }
    }
}
