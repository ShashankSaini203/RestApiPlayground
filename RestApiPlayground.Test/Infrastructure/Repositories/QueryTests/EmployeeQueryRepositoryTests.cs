using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using RestApiPlayground.Infrastructure.Data;
using RestApiPlayground.Infrastructure.Repositories.Query;

namespace RestApiPlayground.Test.Infrastructure.Repositories.QueryTests
{
    [TestFixture]
    public class EmployeeQueryRepositoryTests
    {
        private Mock<IDbConnector> _connectorMock;
        private Mock<IConfiguration> _configurationMock;
        private EmployeeQueryRepository _repository;

        [SetUp]
        public void Setup()
        {
            _configurationMock = new Mock<IConfiguration>();
            _connectorMock = new Mock<IDbConnector>(MockBehavior.Strict)
            {
                CallBase = true
            };
            _connectorMock.Setup(x => x.GetConnection()).Returns("DataSource=:memory:");

            _repository = new EmployeeQueryRepository(_configurationMock.Object);
        }

        [Test]
        public async Task GetByIdAsync_ShouldReturnEmployee_WhenEmployeeExists()
        {
            // Arrange
            var employeeId = 1;

            // Act
            var result = await _repository.GetByIdAsync(employeeId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(employeeId, result.Id);
        }
    }
}
