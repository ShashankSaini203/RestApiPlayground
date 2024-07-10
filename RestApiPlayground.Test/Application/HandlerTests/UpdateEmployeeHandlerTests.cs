using Moq;
using NUnit.Framework;
using RestApiPlayground.Application.Handlers.CommandHandler;
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
            //Act
            //Assert

        }
    }
}
