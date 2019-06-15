using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Model : BaseEntity
    {
        public string Name { get; set; }
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}
