using MediatR;
using RestApiPlayground.Application.Commands;
using RestApiPlayground.Application.Mappers;
using RestApiPlayground.Application.Responses;
using RestApiPlayground.Domain.Contracts;
using RestApiPlayground.Domain.Repositories.Command;

namespace RestApiPlayground.Application.Handlers.CommandHandler
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeResponse>
    {
        private readonly IEmployeeCommandRepository _employeeCommandRepository;

        public UpdateEmployeeHandler(IEmployeeCommandRepository employeeCommandRepository)
        {
            _employeeCommandRepository = employeeCommandRepository;
        }
        public async Task<EmployeeResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var mappedEmployee = EmployeeMapper.Mapper.Map<Employee>(request);

            var updatedEmployeeResult = await _employeeCommandRepository.UpdateAsync(mappedEmployee);

            return EmployeeMapper.Mapper.Map<EmployeeResponse>(updatedEmployeeResult);
        }
    }
}
