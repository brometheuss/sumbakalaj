using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLogic.DTO
{
    public class GetFeatureDto
    {
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }
    }
}
