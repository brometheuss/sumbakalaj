using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLogic.DTO
{
    public class AddPostDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int ModelId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int FuelId { get; set; }
    }
}
