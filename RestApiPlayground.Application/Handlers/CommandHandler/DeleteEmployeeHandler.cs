using MediatR;
using RestApiPlayground.Application.Commands;
using RestApiPlayground.Domain.Repositories;

namespace RestApiPlayground.Application.Handlers.CommandHandler
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, string>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        
        public async Task<string> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeToDelete = await _employeeRepository.GetByIdAsync(request.Id);

            if (employeeToDelete is null)
            {
                throw new KeyNotFoundException("Employee does not exist."); 
            }

            await _employeeRepository.DeleteAsync(employeeToDelete);

            return "Employee has been deleted!"; 
        }
    }
}
