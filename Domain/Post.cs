using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Post : BaseEntity
    {
        public int ModelId { get; set; }
        public int UserId { get; set; }
        public int FuelId { get; set; }
        public ICollection<PostFeature> PostFeatures { get; set; }
    }
}
