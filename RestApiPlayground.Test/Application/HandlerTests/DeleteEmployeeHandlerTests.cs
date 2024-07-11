using Moq;
using NUnit.Framework;
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
            var command = new DeleteEmployeeCommand(1);

            _mockEmployeeCommandRepository.Setup(_ => _.DeleteAsync(It.IsAny<Employee>())).Returns(Task.CompletedTask);

            _mockEmployeeCommandRepository.Setup(_ => _.GetByIdAsync(It.IsAny<long>())).ReturnsAsync((Employee emp) => emp);

            var result = _deleteEmployeeHandler.Handle(command, CancellationToken.None);

            _mockEmployeeCommandRepository.Verify(repo => repo.DeleteAsync(It.IsAny<Employee>()), Times.Once);
        }
    }
}
