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
            long testId = 1;
            var expectedEmployee = new Employee()
            {
                Id = testId,
                FirstName = "Monkey D",
                LastName = "Luffy",
                Department = "Pirates",
                Address = "Grand Line",
                Email = "luffy@strawhats.com",
                ContactNumber = "9878978977",
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var testQuery = new GetEmployeeByIdQuery(testId);

            _mockQueryRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<long>())).ReturnsAsync(expectedEmployee);

            //Act
            var result = await _getEmployeeByIdHandler.Handle(testQuery, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Id, Is.EqualTo(expectedEmployee.Id.ToString()));
            Assert.That(result.FirstName, Is.EqualTo(expectedEmployee.FirstName));
            Assert.That(result.LastName, Is.EqualTo(expectedEmployee.LastName));
            Assert.That(result.Department, Is.EqualTo(expectedEmployee.Department));
            Assert.That(result.Address, Is.EqualTo(expectedEmployee.Address));
            Assert.That(result.Email, Is.EqualTo(expectedEmployee.Email));
            Assert.That(result.ContactNumber, Is.EqualTo(expectedEmployee.ContactNumber));
            Assert.That(result.CreationDate, Is.EqualTo(expectedEmployee.CreationDate));
            Assert.That(result.ModifiedDate, Is.EqualTo(expectedEmployee.ModifiedDate));
        }
    }
}
