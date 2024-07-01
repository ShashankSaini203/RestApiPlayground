using MediatR;
using RestApiPlayground.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiPlayground.Application.Queries
{
    internal class GetAllEmployeesQuery : IRequest<IEnumerable<EmployeeResponse>>
    {

    }
}
