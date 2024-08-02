using RestApiPlayground.Domain.Contracts;
using RestApiPlayground.Domain.Repositories.Command.Base;

namespace RestApiPlayground.Domain.Repositories.Command
{
    public interface IEmployeeCommandRepository : ICommandRepository<Employee>
    {
        //Task<Employee> GetByIdAsync(long id);

        Task<Employee> UpdateAsync(Employee entity);
    }
}
