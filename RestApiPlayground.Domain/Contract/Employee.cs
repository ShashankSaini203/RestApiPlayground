using RestApiPlayground.Domain.Contract.Base;
using RestApiPlayground.Domain.Helpers.Attributes;
using System.ComponentModel.DataAnnotations;

namespace RestApiPlayground.Domain.Contracts
{
    public class Employee : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Department { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        public string Address { get; set; }
    }
}
