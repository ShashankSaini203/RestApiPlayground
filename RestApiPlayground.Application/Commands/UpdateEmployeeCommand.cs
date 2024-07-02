using MediatR;
using RestApiPlayground.Application.Responses;
using System.ComponentModel.DataAnnotations;
using RestApiPlayground.Domain.Helpers.Attributes;
using System.Text.Json.Serialization;

namespace RestApiPlayground.Application.Commands
{
    public class UpdateEmployeeCommand : IRequest<EmployeeResponse>
    {
        [Required(ErrorMessage = "Id is required.")]
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Department { get; set; }

        public string Email { get; set; }

        public string ContactNumber { get; set; }

        public string Address { get; set; }

        [JsonIgnore]
        public DateTime ModifiedDate { get; private set; }

        public UpdateEmployeeCommand()
        {
            this.ModifiedDate = DateTime.UtcNow;
        }
    }
}
