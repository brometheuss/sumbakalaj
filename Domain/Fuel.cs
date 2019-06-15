using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Fuel : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Post> Posts { get; set; } 
    }
}
