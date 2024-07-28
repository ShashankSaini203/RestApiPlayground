using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using RestApiPlayground.Domain.Contracts;
using RestApiPlayground.Infrastructure.Data;
using RestApiPlayground.Infrastructure.Repositories.Command;

namespace RestApiPlayground.Test.Infrastructure.Repositories.CommandTests
{
    public class EmployeeCommandRepositoryTests
    {
        private DataContext _dbContext;
        private Mock<DbSet<Employee>> _dbSetMock;
        private EmployeeCommandRepository _repository;
        private List<Employee> _employees;

        [SetUp]
        public void Setup()
        {
            _dbSetMock = new Mock<DbSet<Employee>>();
            _employees = createTestEmployees();

            var queryable = _employees.AsQueryable();
            _dbSetMock.As<IQueryable<Employee>>().Setup(m => m.Provider).Returns(queryable.Provider);
            _dbSetMock.As<IQueryable<Employee>>().Setup(m => m.Expression).Returns(queryable.Expression);
            _dbSetMock.As<IQueryable<Employee>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            _dbSetMock.As<IQueryable<Employee>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());

            // Use SQLite In-Memory Database
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseSqlite("DataSource=:memory:")
                .Options;

            _dbContext = new DataContext(options);

            // Ensure the database is created
            _dbContext.Database.OpenConnection();
            _dbContext.Database.EnsureCreated();

            // Replace the real DbSet with the mocked one
            _dbContext.Employees = _dbSetMock.Object;

            // Initialize repository
            _repository = new EmployeeCommandRepository(_dbContext);
        }

        [Test]
        public async Task GetByIdAsyncCommand_ValidCommand_GiveEmployeeData()
        {
            var employeesList = createTestEmployees();

            //Fix this
            _dbSetMock.Setup(d => d.FindAsync(It.IsAny<object>()))
                .ReturnsAsync((object id) => _employees.FirstOrDefault(e => e.Id == (long)id));

            // Arrange
            var employeeId = 1;

            // Act
            var result = await _repository.GetByIdAsync(employeeId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(employeeId, result.Id);
            Assert.AreEqual("TestFirstName", result.FirstName);
            Assert.AreEqual("TestLastName", result.LastName);

        }

        public List<Employee> createTestEmployees() => new List<Employee>()
        {
            Employee.CreateEmployee(1, "TestFirstName1", "TestLastName1", "TestAddress1", "TestDepartment1", "TestContactNumber1", "TestEmail1"),
            Employee.CreateEmployee(2, "TestFirstName2", "TestLastNWame2", "TestAddress2", "TestDepartment2", "TestContactNumber2", "TestEmail2"),
            Employee.CreateEmployee(3, "TestFirstName3", "TestLastName3", "TestAddress3", "TestDepartment3", "TestContactNumber3", "TestEmail3"),

        };

    }
}
