using MediatR;

namespace RestApiPlayground.Application.Commands
{
    public class DeleteEmployeeCommand : IRequest<string>
    {
        public long Id { get; set; }

        public DeleteEmployeeCommand(long Id)
        {
            this.Id = Id;
        }
    }
}
