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
        private readonly IEmployeeCommandRepository _employeeCommandRepository;

        public CreateEmployeeHandler(IEmployeeCommandRepository employeeCommandRepository)
        {
            _employeeCommandRepository = employeeCommandRepository;
        }

        public async Task<EmployeeResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeEntity = EmployeeMapper.Mapper.Map<Employee>(request);

            if (employeeEntity == null)
            {
                throw new ApplicationException("Unable to map due to an issue with mapper.");
            }

            var resultEmployeeEntity = await _employeeCommandRepository.CreateAsync(employeeEntity);
            return EmployeeMapper.Mapper.Map<EmployeeResponse>(resultEmployeeEntity);

        }
    }
}
