using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BusinessLogic.Commands
{
    public interface IEditRoleCommand : ICommand<AddRoleDto>
    {
    }
}
