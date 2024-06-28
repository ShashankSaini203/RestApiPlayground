using RestApiPlayground.Domain.Contract.Base;
using RestApiPlayground.Domain.Helpers.Attributes;
using System.ComponentModel.DataAnnotations;

namespace RestApiPlayground.Domain.Contracts
{
    public class Employee : BaseEntity
    {
        [Required(ErrorMessage = "FirstName is required.")]
        [MinLength(2, ErrorMessage = "FirstName must be at least 2 characters long.")]
        [NotPlaceholder("string", ErrorMessage = "FirstName cannot be 'string'.")]
        public string FirstName { get; set; }


        [MinLength(2, ErrorMessage = "LastName must be at least 2 characters long.")]
        [NotPlaceholder("string", ErrorMessage = "LastName cannot be 'string'.")]
        public string LastName { get; set; }


        [MinLength(2, ErrorMessage = "Department must be at least 2 characters long.")]
        [NotPlaceholder("string", ErrorMessage = "Department cannot be 'string'.")]
        public string Department { get; set; }


        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage = "Contact Number is required.")]
        [Phone]
        public string ContactNumber { get; set; }


        [MinLength(2, ErrorMessage = "Address must be at least 2 characters long.")]
        [NotPlaceholder("string", ErrorMessage = "Department cannot be 'string'.")]
        public string Address { get; set; }
    }
}
