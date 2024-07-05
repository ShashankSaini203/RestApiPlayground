using MediatR;
using RestApiPlayground.Application.Mappers;
using RestApiPlayground.Application.Queries;
using RestApiPlayground.Application.Responses;
using RestApiPlayground.Domain.Repositories.Command;

namespace RestApiPlayground.Application.Handlers.QueryHandler
{
    public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetAllEmployeesHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<IEnumerable<EmployeeResponse>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var allEmployees = await _employeeRepository.GetAllAsync();
            return EmployeeMapper.Mapper.Map<IEnumerable<EmployeeResponse>>(allEmployees);
        }
    }
}
