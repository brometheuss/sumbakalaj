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
    public class EfEditUserCommand : EfBaseCommand, IEditUserCommand
    {
        public EfEditUserCommand(EfContext context) : base(context)
        {
        }

        public void Execute(GetUserDto request)
        {
            var user = Context.Users.Find(request.Id);

            if (user == null)
                throw new EntityNotFoundException();

            if (request.Email != user.Email && Context.Users.Any(u => u.Email == request.Email))
                throw new EntityAlreadyExistsException();

            if (request.Password != null)
                user.Password = this.ComputeSha256Hash(request.Password);

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Username = request.Username;
            user.RoleId = request.RoleId;

            Context.SaveChanges();
        }
    }
}
