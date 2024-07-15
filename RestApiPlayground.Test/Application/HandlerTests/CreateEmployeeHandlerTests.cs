using Moq;
using NUnit.Framework;
using RestApiPlayground.Application.Commands;
using RestApiPlayground.Application.Handlers.CommandHandler;
using RestApiPlayground.Domain.Contracts;
using RestApiPlayground.Domain.Repositories.Command;

namespace RestApiPlayground.Test.Application.HandlerTests
{
    [TestFixture]
    public class CreateEmployeeHandlerTests
    {
        private Mock<IEmployeeCommandRepository> _mockCommandRepository;

        private CreateEmployeeHandler _createEmployeeHandler;

        [SetUp]
        public void Setup()
        {
            _mockCommandRepository = new Mock<IEmployeeCommandRepository>();

            _createEmployeeHandler = new CreateEmployeeHandler(_mockCommandRepository.Object);
        }

        [Test]
        public async Task CreateEmployeeHandler_ValidCommand_ShouldCreateAndReturnEmployee()
        {
            //Arrange
            var createEmployeeCommand = new CreateEmployeeCommand()
            {
                FirstName = "Monkey D",
                LastName = "Luffy",
                Department = "Pirates",
                Address = "Grand Line",
                Email = "luffy@strawhats.com",
                ContactNumber = "9878978977",
                CreationDate = DateTime.Now
            };

            _mockCommandRepository.Setup(repo => repo.CreateAsync(It.IsAny<Employee>())).ReturnsAsync((Employee emp) => emp);

            //Act
            var result = await _createEmployeeHandler.Handle(createEmployeeCommand, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.FirstName, Is.EqualTo(createEmployeeCommand.FirstName));
            Assert.That(result.LastName, Is.EqualTo(createEmployeeCommand.LastName));
            Assert.That(result.Department, Is.EqualTo(createEmployeeCommand.Department));
            Assert.That(result.Address, Is.EqualTo(createEmployeeCommand.Address));
            Assert.That(result.Email, Is.EqualTo(createEmployeeCommand.Email));
            Assert.That(result.ContactNumber, Is.EqualTo(createEmployeeCommand.ContactNumber));
            Assert.That(result.CreationDate, Is.EqualTo(createEmployeeCommand.CreationDate));
        }
    }
}
