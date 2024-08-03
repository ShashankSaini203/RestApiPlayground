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

            var newEmployeeData = new Employee()
            {
                Id = 1,
                FirstName="NewFirstName",
                LastName="NewLastName",
                Address="NewAddress",
                Department="NewDepartment",
                ContactNumber="NewContactNumber",
                Email="NewEmail1",
                ModifiedDate=DateTime.Now
            };

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
            Assert.That(result.ModifiedDate, Is.EqualTo(newEmployeeData.ModifiedDate));

            //Revert
            var oldData = Employee.CreateEmployee(1, "TestFirstName1", "TestLastName1", "TestAddress1", "TestDepartment1", "TestContactNumber1", "TestEmail1", DateTime.Now);
            await _repository.UpdateAsync(oldData);
        }
    }
}
