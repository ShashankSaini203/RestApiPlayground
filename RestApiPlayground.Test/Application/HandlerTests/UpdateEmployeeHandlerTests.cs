using Moq;
using NUnit.Framework;
using RestApiPlayground.Application.Commands;
using RestApiPlayground.Application.Handlers.CommandHandler;
using RestApiPlayground.Domain.Contracts;
using RestApiPlayground.Domain.Repositories.Command;
using RestApiPlayground.Infrastructure.Repositories.Command;

namespace RestApiPlayground.Test.Application.HandlerTests
{
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
            var updateCommand = new UpdateEmployeeCommand()
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


            //Assert

        }
    }
}
