using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLogic.DTO
{
    public class AddManufacturerDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Name has to be between 2 and 30 characters long.")]
        public string Name { get; set; }
    }
}
