using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using RestApiPlayground.Application.Commands;
using RestApiPlayground.Application.Handlers.CommandHandler;
using RestApiPlayground.Domain.Contracts;
using RestApiPlayground.Domain.Repositories.Command;
using RestApiPlayground.Domain.Repositories.Query;

namespace RestApiPlayground.Test.Application.HandlerTests
{
    [TestFixture]
    public class DeleteEmployeeHandlerTests
    {
        private Mock<IEmployeeCommandRepository> _mockEmployeeCommandRepository;
        private Mock<IEmployeeQueryRepository> _mockEmployeeQueryRepository;

        private DeleteEmployeeHandler _deleteEmployeeHandler;

        [SetUp]
        public void SetUp()
        {
            _mockEmployeeCommandRepository = new Mock<IEmployeeCommandRepository>();
            _mockEmployeeQueryRepository = new Mock<IEmployeeQueryRepository>();
            _deleteEmployeeHandler = new DeleteEmployeeHandler(_mockEmployeeCommandRepository.Object, _mockEmployeeQueryRepository.Object);
        }

        [Test]
        public async Task DeleteEmployeeHandler_ValidCommand_ShouldDeleteEmployee()
        {
            //Arrange
            long testId = 1;
            var command = new DeleteEmployeeCommand(testId);

            _mockEmployeeCommandRepository.Setup(_ => _.DeleteAsync(It.IsAny<Employee>())).Returns(Task.CompletedTask);
            _mockEmployeeQueryRepository.Setup(_ => _.GetByIdAsync(It.IsAny<long>())).ReturnsAsync(new Employee());

            //Act
            var result = await _deleteEmployeeHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.That(result, Is.EqualTo("Employee has been deleted!"));
            _mockEmployeeQueryRepository.Verify(repo => repo.GetByIdAsync(It.IsAny<long>()), Times.Once);
            _mockEmployeeCommandRepository.Verify(repo => repo.DeleteAsync(It.IsAny<Employee>()), Times.Once);
        }
    }
}
