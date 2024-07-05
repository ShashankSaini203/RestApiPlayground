using RestApiPlayground.Domain.Contracts;
using RestApiPlayground.Domain.Repositories.Query.Base;

namespace RestApiPlayground.Domain.Repositories.Query
{
    public interface IEmployeeQueryRepository : IQueryRepository<Employee>
    {
        Task<Employee> GetEmployeeByIdAsync(long id);
    }
}
