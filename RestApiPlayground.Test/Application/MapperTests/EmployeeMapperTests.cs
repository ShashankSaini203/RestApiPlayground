using NUnit.Framework;
using RestApiPlayground.Application.Commands;
using RestApiPlayground.Application.Mappers;
using RestApiPlayground.Application.Responses;
using RestApiPlayground.Domain.Contracts;

namespace RestApiPlayground.Test.Application.MapperTests
{
    [TestFixture]
    public class EmployeeMapperTests
    {
        [Test]
        public void ShouldMap_UpdateEmployeeCommand_To_Employee()
        {
            var updateEmployeeCommand = new UpdateEmployeeCommand()
            {
                Id = 1,
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "TestAddress",
                Department = "TestDepartment",
                ContactNumber = "TestContactNumber",
                Email = "TestEmail"
            };

            var result = EmployeeMapper.Mapper.Map<Employee>(updateEmployeeCommand);

            Assert.NotNull(result);
            Assert.That(result.Id, Is.EqualTo(updateEmployeeCommand.Id));
            Assert.That(result.FirstName, Is.EqualTo(updateEmployeeCommand.FirstName));
            Assert.That(result.LastName, Is.EqualTo(updateEmployeeCommand.LastName));
            Assert.That(result.Address, Is.EqualTo(updateEmployeeCommand.Address));
            Assert.That(result.Department, Is.EqualTo(updateEmployeeCommand.Department));
            Assert.That(result.ContactNumber, Is.EqualTo(updateEmployeeCommand.ContactNumber));
            Assert.That(result.Email, Is.EqualTo(updateEmployeeCommand.Email));
        }
    }
}
