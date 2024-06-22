using RestApiPlayground.Domain.Contracts;
using RestApiPlayground.Domain.Interfaces;

namespace RestApiPlayground.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees = new List<Employee>
    {
        new Employee { Id = 1, Name = "John Doe", Contact = "IT" },
        new Employee { Id = 2, Name = "Jane Smith", Contact = "HR" },
        new Employee { Id = 3, Name = "Michael Johnson", Contact = "Finance" }
        // Add more mock data as needed
    };

        public Task<IEnumerable<Employee>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Employee>>(_employees);
        }

        public Task<Employee> GetByIdAsync(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            return Task.FromResult(employee);
        }

        public Task AddAsync(Employee employee)
        {
            employee.Id = _employees.Max(e => e.Id) + 1; // Auto-increment ID logic
            _employees.Add(employee);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Employee employee)
        {
            var existingEmployee = _employees.FirstOrDefault(e => e.Id == employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Contact = employee.Contact;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var employeeToRemove = _employees.FirstOrDefault(e => e.Id == id);
            if (employeeToRemove != null)
            {
                _employees.Remove(employeeToRemove);
            }
            return Task.CompletedTask;
        }
    }
}
