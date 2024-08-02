using MediatR;
using RestApiPlayground.Application.Commands;
using RestApiPlayground.Domain.Repositories.Command;
using RestApiPlayground.Domain.Repositories.Query;

namespace RestApiPlayground.Application.Handlers.CommandHandler
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, string>
    {
        private readonly IEmployeeCommandRepository _employeeCommandRepository;

        private readonly IEmployeeQueryRepository _employeeQueryRepository;

        public DeleteEmployeeHandler(IEmployeeCommandRepository employeeCommandRepository, IEmployeeQueryRepository employeeQueryRepository)
        {
            _employeeCommandRepository = employeeCommandRepository;
            _employeeQueryRepository = employeeQueryRepository;
        }

        public async Task<string> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeToDelete = await _employeeQueryRepository.GetByIdAsync(request.Id);

            if (employeeToDelete is null)
            {
                throw new KeyNotFoundException("Employee does not exist.");
            }

            await _employeeCommandRepository.DeleteAsync(employeeToDelete);

            return "Employee has been deleted!";
        }
    }
}
