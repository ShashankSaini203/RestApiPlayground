using System.ComponentModel.DataAnnotations;

namespace RestApiPlayground.Domain.Contracts
{
    public class Employee
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Contact is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string Contact { get; set; }
    }
}
