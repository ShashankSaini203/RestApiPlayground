using RestApiPlayground.Domain.Contracts;
using RestApiPlayground.Domain.Repositories;
using RestApiPlayground.Infrastructure.Data;
using RestApiPlayground.Infrastructure.Repositories.Base;

namespace RestApiPlayground.Infrastructure.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly DataContext _dataContext;
        public EmployeeRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Employee> GetByIdAsync(int id) => await _dataContext.Set<Employee>().FindAsync(id);
    }
}
