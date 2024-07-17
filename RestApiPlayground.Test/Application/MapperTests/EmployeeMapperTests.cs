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
        public void ShouldMap_CreateEmployeeCommand_To_Employee()
        {
            var createEmployeeCommand = new CreateEmployeeCommand()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "TestAddress",
                Department = "TestDepartment",
                ContactNumber = "TestContactNumber",
                Email = "TestEmail",
                CreationDate = DateTime.Now
            };

            var result = EmployeeMapper.Mapper.Map<Employee>(createEmployeeCommand);

            Assert.NotNull(result);
            Assert.That(result.FirstName, Is.EqualTo(createEmployeeCommand.FirstName));
            Assert.That(result.LastName, Is.EqualTo(createEmployeeCommand.LastName));
            Assert.That(result.Address, Is.EqualTo(createEmployeeCommand.Address));
            Assert.That(result.Department, Is.EqualTo(createEmployeeCommand.Department));
            Assert.That(result.ContactNumber, Is.EqualTo(createEmployeeCommand.ContactNumber));
            Assert.That(result.Email, Is.EqualTo(createEmployeeCommand.Email));
            Assert.That(result.CreationDate, Is.EqualTo(createEmployeeCommand.CreationDate));
        }

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

        [Test]
        public void ShouldMap_EmployeeResponse_To_Employee()
        {
            var employeeResponse = createTestEmployeeResponse();

            var result = EmployeeMapper.Mapper.Map<Employee>(employeeResponse);

            Assert.NotNull(result);
            Assert.That(result.Id.ToString(), Is.EqualTo(employeeResponse.Id));
            Assert.That(result.FirstName, Is.EqualTo(employeeResponse.FirstName));
            Assert.That(result.LastName, Is.EqualTo(employeeResponse.LastName));
            Assert.That(result.Address, Is.EqualTo(employeeResponse.Address));
            Assert.That(result.Department, Is.EqualTo(employeeResponse.Department));
            Assert.That(result.ContactNumber, Is.EqualTo(employeeResponse.ContactNumber));
            Assert.That(result.Email, Is.EqualTo(employeeResponse.Email));
        }

        [Test]
        public void ShouldMap_Employee_To_EmployeeResponse()
        {
            var employee = createTestEmployee();

            var result = EmployeeMapper.Mapper.Map<EmployeeResponse>(employee);

            Assert.NotNull(result);
            Assert.That(long.Parse(result.Id), Is.EqualTo(employee.Id));
            Assert.That(result.FirstName, Is.EqualTo(employee.FirstName));
            Assert.That(result.LastName, Is.EqualTo(employee.LastName));
            Assert.That(result.Address, Is.EqualTo(employee.Address));
            Assert.That(result.Department, Is.EqualTo(employee.Department));
            Assert.That(result.ContactNumber, Is.EqualTo(employee.ContactNumber));
            Assert.That(result.Email, Is.EqualTo(employee.Email));
            Assert.That(result.CreationDate, Is.EqualTo(employee.CreationDate));
            Assert.That(result.ModifiedDate, Is.EqualTo(employee.ModifiedDate));

        }

        public Employee createTestEmployee() => new Employee()
        {
            Id = 1,
            FirstName = "TestFirstName",
            LastName = "TestLastName",
            Address = "TestAddress",
            Department = "TestDepartment",
            ContactNumber = "TestContactNumber",
            Email = "TestEmail",
            CreationDate = DateTime.Now,
            ModifiedDate = DateTime.Now

        };

        public EmployeeResponse createTestEmployeeResponse() => new EmployeeResponse()
        {
            Id = "1",
            FirstName = "TestFirstName",
            LastName = "TestLastName",
            Address = "TestAddress",
            Department = "TestDepartment",
            ContactNumber = "TestContactNumber",
            Email = "TestEmail",
            CreationDate = DateTime.Now,
            ModifiedDate = DateTime.Now

        };
    }
}
