﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLogic.DTO
{
    public class AddRoleDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
