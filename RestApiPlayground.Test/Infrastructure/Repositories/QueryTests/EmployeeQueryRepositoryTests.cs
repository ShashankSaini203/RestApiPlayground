﻿using Moq;
using NUnit.Framework;
using RestApiPlayground.Infrastructure.Data;
using RestApiPlayground.Infrastructure.Repositories.Query;

namespace RestApiPlayground.Test.Infrastructure.Repositories.QueryTests
{
    [TestFixture]
    public class EmployeeQueryRepositoryTests
    {
        private Mock<IDbConnector> _connectorMock;
        private EmployeeQueryRepository _repository;

        [SetUp]
        public void Setup()
        {
            _connectorMock = new Mock<IDbConnector>();

            var dbConnection = TestDatabaseHelper.SharedConnection;
            _connectorMock.Setup(x => x.CreateConnection()).Returns(dbConnection);

            _repository = new EmployeeQueryRepository(_connectorMock.Object);
        }

        [Test]
        public async Task GetByIdAsync_ShouldReturnEmployee_WhenEmployeeExists()
        {
            // Arrange
            long employeeId = 1;

            // Act
            var result = await _repository.GetByIdAsync(employeeId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(employeeId, result.Id);
            Assert.AreEqual("TestFirstName1", result.FirstName);
            Assert.AreEqual("TestLastName1", result.LastName);
            Assert.AreEqual("TestAddress1", result.Address);
            Assert.AreEqual("TestDepartment1", result.Department);
            Assert.AreEqual("TestEmail1", result.Email);
            Assert.AreEqual("TestContactNumber1", result.ContactNumber);
        }
    }
}
