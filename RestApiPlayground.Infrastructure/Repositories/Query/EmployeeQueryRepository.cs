using Microsoft.Extensions.Configuration;
using RestApiPlayground.Domain.Contracts;
using RestApiPlayground.Domain.Repositories.Query;
using RestApiPlayground.Infrastructure.Repositories.Query.Base;

namespace RestApiPlayground.Infrastructure.Repositories.Query
{
    public class EmployeeQueryRepository : QueryRepository<Employee>, IEmployeeQueryRepository
    {
        public EmployeeQueryRepository(IConfiguration configuration) : base(configuration) { }

        public Task<Employee> GetEmployeeByIdAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
