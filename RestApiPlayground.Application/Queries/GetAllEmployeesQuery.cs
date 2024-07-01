using MediatR;
using RestApiPlayground.Application.Responses;

namespace RestApiPlayground.Application.Queries
{
    public class GetAllEmployeesQuery : IRequest<IEnumerable<EmployeeResponse>>
    {
    }
}
