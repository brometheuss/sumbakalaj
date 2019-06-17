using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLogic.DTO
{
    public class AddRoleDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Must be between 2 and 30 characters long.")]
        public string Name { get; set; }
    }
}
