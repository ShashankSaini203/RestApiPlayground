using Dapper;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using RestApiPlayground.Domain.Contracts;
using RestApiPlayground.Infrastructure.Data;
using RestApiPlayground.Infrastructure.Repositories.Query;
using System.Data;

namespace RestApiPlayground.Test.Infrastructure.Repositories.QueryTests
{
    [TestFixture]
    public class EmployeeQueryRepositoryTests
    {
        private Mock<IConfiguration> _mockConfiguration;
        private Mock<IDbConnection> _mockDbConnection;
        private Mock<DbConnector> _mockDbConnector;
        private EmployeeQueryRepository _repository;

        [SetUp]
        public void Setup()
        {
            _mockConfiguration = new Mock<IConfiguration>();
            _mockDbConnection = new Mock<IDbConnection>();
            _mockDbConnector = new Mock<DbConnector>();

            _repository = new EmployeeQueryRepository(_mockConfiguration.Object);
        }

        [Test]
        public async Task GetByIdAsync_ShouldReturnEmployee_WhenEmployeeExists()
        {
            // Arrange
            var employeeId = 1;
            var employee = new Employee { Id = employeeId, FirstName = "John Doe" };

            _mockDbConnector.Setup(x => x.CreateConnection()).Returns(_mockDbConnection.Object);
            _mockDbConnection
                .Setup(x => x.QueryFirstOrDefaultAsync<Employee>(It.IsAny<string>(), It.IsAny<object>(), null, null, null))
                .ReturnsAsync(employee);

            // Act
            var result = await _repository.GetByIdAsync(employeeId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(employeeId, result.Id);
        }
    }
}
