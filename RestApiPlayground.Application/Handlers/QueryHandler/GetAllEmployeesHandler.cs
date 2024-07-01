using MediatR;
using RestApiPlayground.Application.Mappers;
using RestApiPlayground.Application.Queries;
using RestApiPlayground.Application.Responses;
using RestApiPlayground.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiPlayground.Application.Handlers.QueryHandler
{
    internal class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeResponse>>
    {
        private IEmployeeRepository _employeeRepository;

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
