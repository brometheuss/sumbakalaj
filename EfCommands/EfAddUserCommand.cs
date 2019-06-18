using BusinessLogic.Commands;
using BusinessLogic.DTO;
using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfAddUserCommand : EfBaseCommand, IAddUserCommand
    {
        protected readonly IEmailSender _emailSender;
        public EfAddUserCommand(EfContext context, IEmailSender emailSender) : base(context)
        {
            _emailSender = emailSender;
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

            _emailSender.Body = "User created";
            _emailSender.Subject = "You successfully added a new user.";
            _emailSender.ToEmail = "netcoreict@gmail.com";
            _emailSender.Send();
        }
    }
}
