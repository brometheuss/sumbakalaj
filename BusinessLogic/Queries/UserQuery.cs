using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Queries
{
    public class UserQuery : BaseQuery
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
    }
}
