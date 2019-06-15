using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Queries
{
    public class BaseQuery
    {
        public int PerPage { get; set; } = 15;
        public int PageNumber { get; set; } = 1;
    }
}
