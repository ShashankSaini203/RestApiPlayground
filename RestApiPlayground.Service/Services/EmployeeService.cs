using RestApiPlayground.Domain.Contracts;
using RestApiPlayground.Domain.Repositories;

namespace RestApiPlayground.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }   

        public Task<IEnumerable<Employee>> GetAllAsync()
        {
            return _employeeRepository.GetAllAsync();
        }

        public Task<Employee> GetByIdAsync(int id)
        {
            return _employeeRepository.GetByIdAsync(id);
        }

        public Task CreateAsync(Employee employee)
        {
            return _employeeRepository.CreateAsync(employee);
        }

        public Task UpdateAsync(Employee employee)
        {
            return _employeeRepository.UpdateAsync(employee);
        }

        public Task DeleteAsync(int id)
        {
            return _employeeRepository.DeleteAsync(id);
        }

    }
}
