using Moq;
using NUnit.Framework;
using RestApiPlayground.Application.Handlers.QueryHandler;
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
        }
    }
}
