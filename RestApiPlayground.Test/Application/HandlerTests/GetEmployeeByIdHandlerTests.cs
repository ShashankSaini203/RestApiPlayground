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
        private GetEmployeeByIdHandler getEmployeeByIdHandler;

        [SetUp]
        public void Setup()
        {
            _mockQueryRepository = new Mock<IEmployeeQueryRepository>();
            getEmployeeByIdHandler = new GetEmployeeByIdHandler(_mockQueryRepository.Object);
        }

        [Test]
        public async Task GetEmployeeByIdQueryHandler_ValidQuery_ShouldReturnEmployee()
        {
        }
    }
}
