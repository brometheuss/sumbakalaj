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
    public class EfAddUserCommand : EfBaseCommand, IAddUserCommand
    {
        public EfAddUserCommand(EfContext context) : base(context)
        {
        }

        public void Execute(AddUserDto request)
        {
            if (Context.Users.Any(u => u.Email == request.Password))
                throw new EntityAlreadyExistsException();

            Context.Users.Add(new Domain.User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Username = request.Username,
                Password = this.ComputeSha256Hash(request.Password),
                RoleId = request.RoleId
            });

            Context.SaveChanges();
        }
    }
}
