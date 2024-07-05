using MediatR;
using RestApiPlayground.Application.Commands;
using RestApiPlayground.Domain.Repositories.Command;

namespace RestApiPlayground.Application.Handlers.CommandHandler
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, string>
    {
        private readonly IEmployeeCommandRepository _employeeCommandRepository;

        public DeleteEmployeeHandler(IEmployeeCommandRepository employeeCommandRepository)
        {
            _employeeCommandRepository = employeeCommandRepository;
        }

        public async Task<string> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeToDelete = await _employeeCommandRepository.GetByIdAsync(request.Id);

            if (employeeToDelete is null)
            {
                throw new KeyNotFoundException("Employee does not exist.");
            }

            await _employeeCommandRepository.DeleteAsync(employeeToDelete);

            return "Employee has been deleted!";
        }
    }
}
