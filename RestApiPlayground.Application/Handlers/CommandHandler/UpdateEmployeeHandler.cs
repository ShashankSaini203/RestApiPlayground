using MediatR;
using RestApiPlayground.Application.Commands;
using RestApiPlayground.Application.Mappers;
using RestApiPlayground.Application.Responses;
using RestApiPlayground.Domain.Contracts;
using RestApiPlayground.Domain.Repositories;

namespace RestApiPlayground.Application.Handlers.CommandHandler
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public UpdateEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<EmployeeResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var mappedEmployee = EmployeeMapper.Mapper.Map<Employee>(request);

            var updatedEmployeeResult = await _employeeRepository.UpdateAsync(mappedEmployee);

            return EmployeeMapper.Mapper.Map<EmployeeResponse>(updatedEmployeeResult);
        }
    }
}
