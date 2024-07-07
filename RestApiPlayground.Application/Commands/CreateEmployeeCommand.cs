using MediatR;
using RestApiPlayground.Application.Responses;
using RestApiPlayground.Domain.Helpers.Attributes;
using System.ComponentModel.DataAnnotations;

namespace RestApiPlayground.Application.Commands
{
    public class CreateEmployeeCommand : IRequest<EmployeeResponse>
    {
        [NotPlaceholder("string", ErrorMessage = "FirstName cannot be 'string'.")]
        public string FirstName { get; set; }


        [NotPlaceholder("string", ErrorMessage = "LastName cannot be 'string'.")]
        public string LastName { get; set; }


        [NotPlaceholder("string", ErrorMessage = "Department cannot be 'string'.")]
        public string Department { get; set; }

        public string Email { get; set; }

        public string ContactNumber { get; set; }


        [MinLength(2, ErrorMessage = "Address must be at least 2 characters long.")]
        [NotPlaceholder("string", ErrorMessage = "Department cannot be 'string'.")]
        public string Address { get; set; }

        public DateTime CreationDate { get; set; }

    }
}
