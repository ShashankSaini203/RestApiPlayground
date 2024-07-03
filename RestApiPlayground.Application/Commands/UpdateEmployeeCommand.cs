using MediatR;
using RestApiPlayground.Application.Responses;
using RestApiPlayground.Domain.Helpers.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RestApiPlayground.Application.Commands
{
    public class UpdateEmployeeCommand : IRequest<EmployeeResponse>
    {
        [Required(ErrorMessage = "Id is required.")]
        public long Id { get; set; }

        [NotPlaceholder("string", ErrorMessage = "LastName cannot be 'string'.")]
        public string? FirstName { get; set; }

        [NotPlaceholder("string", ErrorMessage = "LastName cannot be 'string'.")]
        public string? LastName { get; set; }

        [NotPlaceholder("string", ErrorMessage = "LastName cannot be 'string'.")]
        public string? Department { get; set; }

        [NotPlaceholder("string", ErrorMessage = "LastName cannot be 'string'.")]
        public string? Email { get; set; }

        [NotPlaceholder("string", ErrorMessage = "LastName cannot be 'string'.")]
        public string? ContactNumber { get; set; }

        [NotPlaceholder("string", ErrorMessage = "LastName cannot be 'string'.")]
        public string? Address { get; set; }

        [JsonIgnore]
        public DateTime ModifiedDate { get; private set; }

        public UpdateEmployeeCommand()
        {
            this.ModifiedDate = DateTime.Now;
        }
    }
}
