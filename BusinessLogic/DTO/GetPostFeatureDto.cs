using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.DTO
{
    public class GetPostFeatureDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ModelId { get; set; }
        public int FuelId { get; set; }
        public int UserId { get; set; }
    }
}
