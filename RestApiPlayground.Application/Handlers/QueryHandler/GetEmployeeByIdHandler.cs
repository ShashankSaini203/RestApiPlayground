using MediatR;
using RestApiPlayground.Application.Mappers;
using RestApiPlayground.Application.Queries;
using RestApiPlayground.Application.Responses;
using RestApiPlayground.Domain.Repositories.Command;
using RestApiPlayground.Domain.Repositories.Query;
using RestApiPlayground.Infrastructure.Repositories.Query;

namespace RestApiPlayground.Application.Handlers.QueryHandler
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeResponse>
    {
        private readonly IEmployeeQueryRepository _employeeQueryRepository;

        public GetEmployeeByIdHandler(IEmployeeQueryRepository employeeQueryRepository)
        {
            _employeeQueryRepository = employeeQueryRepository;
        }
        public async Task<EmployeeResponse> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _employeeQueryRepository.GetByIdAsync(request.Id);

            return EmployeeMapper.Mapper.Map<EmployeeResponse>(result);
        }
    }
}
