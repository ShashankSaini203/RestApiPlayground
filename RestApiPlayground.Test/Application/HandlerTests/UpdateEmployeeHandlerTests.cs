using Moq;
using NUnit.Framework;
using RestApiPlayground.Application.Commands;
using RestApiPlayground.Application.Handlers.CommandHandler;
using RestApiPlayground.Domain.Contracts;
using RestApiPlayground.Domain.Repositories.Command;

namespace RestApiPlayground.Test.Application.HandlerTests
{
    [TestFixture]
    public class UpdateEmployeeHandlerTests
    {
        private Mock<IEmployeeCommandRepository> _mockCommandRepository;

        private UpdateEmployeeHandler _updateEmployeeHandler;

        [SetUp]
        public void Setup()
        {
            _mockCommandRepository = new Mock<IEmployeeCommandRepository>();

            _updateEmployeeHandler = new UpdateEmployeeHandler(_mockCommandRepository.Object);
        }

        [Test]
        public async Task UpdateEmployeeHandler_ValidCommand_ShouldUpdateAndReturnUpdatedEmployee()
        {
            //Arrange
            var updateEmployeeCommand = new UpdateEmployeeCommand()
            {
                Id = 11,
                FirstName = "Monkey D",
                LastName = "Luffy",
                Department = "Pirates",
                Address = "Grand Line",
                Email = "luffy@strawhats.com",
                ContactNumber = "9878978977"
            };

            _mockCommandRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Employee>())).ReturnsAsync((Employee emp) => emp);

            //Act

            var result = await _updateEmployeeHandler.Handle(updateEmployeeCommand, CancellationToken.None);

            //Assert

            Assert.IsNotNull(result);
            Assert.NotNull(result);
            Assert.That(result.FirstName, Is.EqualTo(updateEmployeeCommand.FirstName));
            Assert.That(result.LastName, Is.EqualTo(updateEmployeeCommand.LastName));
            Assert.That(result.Department, Is.EqualTo(updateEmployeeCommand.Department));
            Assert.That(result.Address, Is.EqualTo(updateEmployeeCommand.Address));
            Assert.That(result.Email, Is.EqualTo(updateEmployeeCommand.Email));
            Assert.That(result.ContactNumber, Is.EqualTo(updateEmployeeCommand.ContactNumber));
            Assert.That(result.ModifiedDate, Is.EqualTo(updateEmployeeCommand.ModifiedDate));
        }
    }
}
