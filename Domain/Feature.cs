using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Feature : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<PostFeature> PostFeatures { get; set; }
    }
}
