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
        [Phone(ErrorMessage = "Invalid phone number format.")]
        [NotPlaceholder("string", ErrorMessage = "Name cannot be 'string'.")]
        public string Contact { get; set; }
    }
}
