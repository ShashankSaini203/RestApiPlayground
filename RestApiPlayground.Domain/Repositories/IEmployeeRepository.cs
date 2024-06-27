using RestApiPlayground.Domain.Contracts;
using RestApiPlayground.Domain.Repositories.Base;

namespace RestApiPlayground.Domain.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Employee> GetByIdAsync(int id);
    }
}
