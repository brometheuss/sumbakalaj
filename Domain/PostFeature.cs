using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class PostFeature : BaseEntity
    {
        public int PostId { get; set; }
        public int FeatureId { get; set; }

        public Post Post { get; set; }
        public Feature Feature { get; set; }
    }
}
