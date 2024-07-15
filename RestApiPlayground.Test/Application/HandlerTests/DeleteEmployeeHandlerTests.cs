using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using RestApiPlayground.Application.Commands;
using RestApiPlayground.Application.Handlers.CommandHandler;
using RestApiPlayground.Domain.Contracts;
using RestApiPlayground.Domain.Repositories.Command;

namespace RestApiPlayground.Test.Application.HandlerTests
{
    [TestFixture]
    public class DeleteEmployeeHandlerTests
    {
        private Mock<IEmployeeCommandRepository> _mockEmployeeCommandRepository;

        private DeleteEmployeeHandler _deleteEmployeeHandler;

        [SetUp]
        public void SetUp()
        {
            _mockEmployeeCommandRepository = new Mock<IEmployeeCommandRepository>();
            _deleteEmployeeHandler = new DeleteEmployeeHandler(_mockEmployeeCommandRepository.Object);
        }

        [Test]
        public async Task DeleteEmployeeHandler_ValidCommand_ShouldDeleteEmployee()
        {
            //Arrange
            long testId = 1;
            var command = new DeleteEmployeeCommand(testId);

            _mockEmployeeCommandRepository.Setup(_ => _.DeleteAsync(It.IsAny<Employee>())).Returns(Task.CompletedTask);
            _mockEmployeeCommandRepository.Setup(_ => _.GetByIdAsync(It.IsAny<long>())).ReturnsAsync(new Employee());

            //Act
            var result = await _deleteEmployeeHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.That(result, Is.EqualTo("Employee has been deleted!"));
            _mockEmployeeCommandRepository.Verify(repo => repo.GetByIdAsync(It.IsAny<long>()), Times.Once);
            _mockEmployeeCommandRepository.Verify(repo => repo.DeleteAsync(It.IsAny<Employee>()), Times.Once);
        }
    }
}
