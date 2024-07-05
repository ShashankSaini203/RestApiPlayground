using MediatR;
using RestApiPlayground.Application.Mappers;
using RestApiPlayground.Application.Queries;
using RestApiPlayground.Application.Responses;
using RestApiPlayground.Domain.Repositories.Query;

namespace RestApiPlayground.Application.Handlers.QueryHandler
{
    public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeResponse>>
    {
        private readonly IEmployeeQueryRepository _employeeQueryRepository;

        public GetAllEmployeesHandler(IEmployeeQueryRepository employeeQueryRepository)
        {
            _employeeQueryRepository = employeeQueryRepository;
        }
        public async Task<IEnumerable<EmployeeResponse>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var allEmployees = await _employeeQueryRepository.GetAllAsync();
            return EmployeeMapper.Mapper.Map<IEnumerable<EmployeeResponse>>(allEmployees);
        }
    }
}
