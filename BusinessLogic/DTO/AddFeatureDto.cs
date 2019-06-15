using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLogic.DTO
{
    public class AddFeatureDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
