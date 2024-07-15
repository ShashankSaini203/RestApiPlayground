using Moq;
using NUnit.Framework;
using RestApiPlayground.Application.Handlers.QueryHandler;
using RestApiPlayground.Domain.Repositories.Query;

namespace RestApiPlayground.Test.Application.HandlerTests
{
    [TestFixture]
    public class GetAllEmployeesHandlerTests
    {
        private Mock<IEmployeeQueryRepository> _mockQueryRepository;
        private GetAllEmployeesHandler _getAllEmployeesHandler;

        [SetUp]
        public void Setup()
        {
            _mockQueryRepository = new Mock<IEmployeeQueryRepository>();
            _getAllEmployeesHandler = new GetAllEmployeesHandler(_mockQueryRepository.Object);
        }

        [Test]
        public async Task GetAllEmployeesHandler_ValidQuery_ShouldReturnAllEmployees()
        {
        }
    }
}
