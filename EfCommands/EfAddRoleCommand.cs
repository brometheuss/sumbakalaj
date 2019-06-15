using BusinessLogic.Commands;
using BusinessLogic.DTO;
using BusinessLogic.Exceptions;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfAddRoleCommand : EfBaseCommand,IAddRoleCommand
    {
        public EfAddRoleCommand(EfContext context) : base(context)
        {

        }
        public void Execute(AddRoleDto request)
        {
            if (Context.Roles.Any(r => r.Name == request.Name))
                throw new EntityAlreadyExistsException();

            Context.Roles.Add(new Role
            {
                Name = request.Name
            });

            Context.SaveChanges();
        }
    }
}
