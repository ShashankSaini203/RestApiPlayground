using Dapper;
using Microsoft.Extensions.Configuration;
using Moq;
using Moq.Dapper;
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
        private Mock<IDbConnector> _mockDbConnector;
        private Mock<EmployeeQueryRepository> _mockRepository;

        [SetUp]
        public void Setup()
        {
            _mockConfiguration = new Mock<IConfiguration>();
            _mockDbConnection = new Mock<IDbConnection>();
            _mockDbConnector = new Mock<IDbConnector>();

            _mockRepository = new Mock<EmployeeQueryRepository>(_mockConfiguration.Object) { CallBase = true };
            _mockDbConnector.Setup(x => x.CreateConnection()).Returns(_mockDbConnection.Object);
        }

        [Test]
        public async Task GetByIdAsync_ShouldReturnEmployee_WhenEmployeeExists()
        {
            // Arrange
            var employeeId = 1;
            var employee = new Employee { Id = employeeId, FirstName = "John Doe" };

            _mockDbConnection
                .SetupDapperAsync(x => x.QueryFirstOrDefaultAsync<Employee>(It.IsAny<string>(), It.IsAny<object>(), null, null, null))
                .ReturnsAsync(employee);

            // Act
            var result = await _mockRepository.Object.GetByIdAsync(employeeId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(employeeId, result.Id);
        }
    }
}
