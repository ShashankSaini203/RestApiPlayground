﻿using Microsoft.EntityFrameworkCore;
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

        [OneTimeSetUp]
        public void Setup()
        {
            _dbContext = TestDatabaseHelper.DbContext;

            // Initialize repository
            _repository = new EmployeeCommandRepository(_dbContext);
        }

        [Test]
        public async Task UpdateAsync_ValidCommand_UpdatesEmployeeData()
        {
            
            var newEmployeeData = Employee.CreateEmployee(1,
                "NewFirstName",
                "NewLastName",
                "NewAddress",
                "NewDepartment",
                "NewContactNumber",
                "NewEmail1");

            // Act
            var result = await _repository.UpdateAsync(newEmployeeData);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.FirstName, Is.EqualTo(newEmployeeData.FirstName));
            Assert.That(result.LastName, Is.EqualTo(newEmployeeData.LastName));
            Assert.That(result.Address, Is.EqualTo(newEmployeeData.Address));
            Assert.That(result.Department, Is.EqualTo(newEmployeeData.Department));
            Assert.That(result.ContactNumber, Is.EqualTo(newEmployeeData.ContactNumber));
            Assert.That(result.Email, Is.EqualTo(newEmployeeData.Email));
            Assert.That(result.CreationDate, Is.EqualTo(newEmployeeData.CreationDate));

            //Revert
            var oldData = Employee.CreateEmployee(1, "TestFirstName1", "TestLastName1", "TestAddress1", "TestDepartment1", "TestContactNumber1", "TestEmail1");
            var revertedResult = await _repository.UpdateAsync(oldData);
        }
    }
}
