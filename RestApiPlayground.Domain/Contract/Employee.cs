using RestApiPlayground.Domain.Contract.Base;
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

        public static Employee CreateEmployee(int id, string firstName, string lastName, string address, string department, string contactNumber, string email) =>
            new Employee
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                Department = department,
                ContactNumber = contactNumber,
                Email = email
            };
    }
}
