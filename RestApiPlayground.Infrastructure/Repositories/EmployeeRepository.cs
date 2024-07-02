using Microsoft.EntityFrameworkCore;
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

        public async Task<Employee> GetByIdAsync(long id)
        {
            _dataContext.Set<Employee>().AsNoTracking();
            return await _dataContext.Set<Employee>().FindAsync(id);
        }

        public async Task<Employee> UpdateAsync(Employee employeeEntity)
        {
            var existingEmployee = await _dataContext.Set<Employee>().FindAsync(employeeEntity.Id);
            
            if (existingEmployee is null)
            {
                throw new KeyNotFoundException($"Employee not found. Please create a new employee with id : {employeeEntity.Id}");
            }

            var updatedEmployee = new Employee()
            {
                FirstName = employeeEntity?.FirstName ?? existingEmployee.FirstName,
                LastName = employeeEntity?.LastName ?? existingEmployee.LastName,
                Address = employeeEntity?.Address ?? existingEmployee.Address,
                Department = employeeEntity?.Department ?? existingEmployee.Department,
                Email = employeeEntity?.Email ?? existingEmployee.Email,
                ContactNumber = employeeEntity?.ContactNumber ?? existingEmployee.ContactNumber
            };

            _dataContext.Set<Employee>().Update(updatedEmployee);
            await _dataContext.SaveChangesAsync();

            return await _dataContext.Set<Employee>().FindAsync(employeeEntity.Id);
        }
    }
}
