using MediatR;
using RestApiPlayground.Application.Commands;
using RestApiPlayground.Application.Mappers;
using RestApiPlayground.Application.Responses;
using RestApiPlayground.Domain.Contracts;
using RestApiPlayground.Domain.Repositories.Command;

namespace RestApiPlayground.Application.Handlers.CommandHandler
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, EmployeeResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeEntity = EmployeeMapper.Mapper.Map<Employee>(request);

            if (employeeEntity == null)
            {
                throw new ApplicationException("Unable to map due to an issue with mapper.");
            }

            var resultEmployeeEntity = await _employeeRepository.CreateAsync(employeeEntity);
            return EmployeeMapper.Mapper.Map<EmployeeResponse>(resultEmployeeEntity);

        }
    }
}
