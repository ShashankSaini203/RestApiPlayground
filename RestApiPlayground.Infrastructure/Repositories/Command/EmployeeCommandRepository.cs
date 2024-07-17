using Microsoft.EntityFrameworkCore;
using RestApiPlayground.Domain.Contracts;
using RestApiPlayground.Domain.Repositories.Command;
using RestApiPlayground.Infrastructure.Data;
using RestApiPlayground.Infrastructure.Repositories.Command.Base;

namespace RestApiPlayground.Infrastructure.Repositories.Command
{
    public class EmployeeCommandRepository : CommandRepository<Employee>, IEmployeeCommandRepository
    {
        private readonly DataContext _dataContext;

        public EmployeeCommandRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Employee> GetByIdAsync(long id)
        {
            try
            {
                _dataContext.Set<Employee>().AsNoTracking();
                return await _dataContext.Set<Employee>().FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Employee> UpdateAsync(Employee employeeEntity)
        {
            try
            {
                var existingEmployee = await _dataContext.Set<Employee>().FindAsync(employeeEntity.Id);

                if (existingEmployee is null)
                {
                    throw new KeyNotFoundException($"Employee not found. Please create a new employee with id : {employeeEntity.Id}");
                }

                existingEmployee.FirstName = employeeEntity?.FirstName ?? existingEmployee.FirstName;
                existingEmployee.LastName = employeeEntity?.LastName ?? existingEmployee.LastName;
                existingEmployee.Address = employeeEntity?.Address ?? existingEmployee.Address;
                existingEmployee.Department = employeeEntity?.Department ?? existingEmployee.Department;
                existingEmployee.Email = employeeEntity?.Email ?? existingEmployee.Email;
                existingEmployee.ContactNumber = employeeEntity?.ContactNumber ?? existingEmployee.ContactNumber;
                existingEmployee.ModifiedDate = employeeEntity.ModifiedDate;

                _dataContext.Set<Employee>().Update(existingEmployee);
                _dataContext.Entry(existingEmployee).State = EntityState.Modified;
                await _dataContext.SaveChangesAsync();

                return existingEmployee;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
