using Moq;
using NUnit.Framework;
using RestApiPlayground.Application.Handlers.QueryHandler;
using RestApiPlayground.Application.Queries;
using RestApiPlayground.Domain.Contracts;
using RestApiPlayground.Domain.Repositories.Query;

namespace RestApiPlayground.Test.Application.HandlerTests
{
    [TestFixture]
    public class GetEmployeeByIdHandlerTests
    {
        private Mock<IEmployeeQueryRepository> _mockQueryRepository;
        private GetEmployeeByIdHandler _getEmployeeByIdHandler;

        [SetUp]
        public void Setup()
        {
            _mockQueryRepository = new Mock<IEmployeeQueryRepository>();
            _getEmployeeByIdHandler = new GetEmployeeByIdHandler(_mockQueryRepository.Object);
        }

        [Test]
        public async Task GetEmployeeByIdHandler_ValidQuery_ShouldReturnEmployee()
        {
            //Arrange
            int testId = 1;

            var testQuery = new GetEmployeeByIdQuery(testId);

            _mockQueryRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<long>())).ReturnsAsync((Employee emp) => emp);

            //Act
            var result = _getEmployeeByIdHandler.Handle(testQuery, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
        }
    }
}
