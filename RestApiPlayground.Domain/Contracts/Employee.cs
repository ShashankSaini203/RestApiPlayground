﻿using RestApiPlayground.Domain.Helpers.Attributes;
using System.ComponentModel.DataAnnotations;

namespace RestApiPlayground.Domain.Contracts
{
    public class Employee
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long.")]
        [NotPlaceholder("string", ErrorMessage = "Name cannot be 'string'.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Contact is required.")]
        [MinLength(2, ErrorMessage = "Department must be at least 2 characters long.")]
        [NotPlaceholder("string", ErrorMessage = "Department cannot be 'string'.")]
        public string Department { get; set; }
    }
}
