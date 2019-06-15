using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Commands
{
    public interface IAddUserCommand : ICommand<AddUserDto>
    {
    }
}
