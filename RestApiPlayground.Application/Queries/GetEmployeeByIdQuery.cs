using MediatR;
using RestApiPlayground.Application.Responses;

namespace RestApiPlayground.Application.Queries
{
    public class GetEmployeeByIdQuery : IRequest<EmployeeResponse>
    {
        public long Id { get; set; }

        public GetEmployeeByIdQuery(long Id)
        {
            this.Id = Id;
        }
    }
}
