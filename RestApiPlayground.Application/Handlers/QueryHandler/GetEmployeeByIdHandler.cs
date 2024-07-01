using AutoMapper;
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
    internal class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeResponse>
    {
        private IEmployeeRepository _employeeRepository;

        public GetEmployeeByIdHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<EmployeeResponse> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _employeeRepository.GetByIdAsync(request.Id);

            return EmployeeMapper.Mapper.Map<EmployeeResponse>(result);
        }
    }
}
