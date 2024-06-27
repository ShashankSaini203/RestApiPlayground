using RestApiPlayground.Domain.Contracts;

namespace RestApiPlayground.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetByIdAsync(int id);
    }
}
