using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using RestApiPlayground.Domain.Contracts;
using RestApiPlayground.Infrastructure.Data;
using RestApiPlayground.Infrastructure.Repositories.Command;

namespace RestApiPlayground.Test.Infrastructure.Repositories.CommandTests
{
    public class EmployeeCommandRepositoryTests
    {
        private DataContext _dbContext;
        private EmployeeCommandRepository _repository;
        private List<Employee> _employees;

        [SetUp]
        public void Setup()
        {
            _employees = createTestEmployees();

            // Use SQLite In-Memory Database
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseSqlite("DataSource=:memory:")
                .Options;

            _dbContext = new DataContext(options);

            // Ensure the database is created
            _dbContext.Database.OpenConnection();
            _dbContext.Database.EnsureCreated();

            // Seed the database with test data
            _dbContext.Employees.AddRange(_employees);
            _dbContext.SaveChanges();

            // Initialize repository
            _repository = new EmployeeCommandRepository(_dbContext);
        }

        [Test]
        public async Task GetByIdAsyncCommand_ValidCommand_GiveEmployeeData()
        {
            var employeeId = 1;

            // Act
            var result = await _repository.GetByIdAsync(employeeId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(employeeId, result.Id);
            Assert.AreEqual("TestFirstName1", result.FirstName);
            Assert.AreEqual("TestLastName1", result.LastName);

        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.CloseConnection();
            _dbContext.Dispose();
        }

        public List<Employee> createTestEmployees() => new List<Employee>()
        {
            Employee.CreateEmployee(1, "TestFirstName1", "TestLastName1", "TestAddress1", "TestDepartment1", "TestContactNumber1", "TestEmail1"),
            Employee.CreateEmployee(2, "TestFirstName2", "TestLastNWame2", "TestAddress2", "TestDepartment2", "TestContactNumber2", "TestEmail2"),
            Employee.CreateEmployee(3, "TestFirstName3", "TestLastName3", "TestAddress3", "TestDepartment3", "TestContactNumber3", "TestEmail3")
        };

    }
}
