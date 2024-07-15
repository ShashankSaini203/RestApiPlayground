using Moq;
using NUnit.Framework;
using RestApiPlayground.Application.Handlers.QueryHandler;
using RestApiPlayground.Application.Queries;
using RestApiPlayground.Domain.Contracts;
using RestApiPlayground.Domain.Repositories.Query;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            //Arrange
            var expectedEmployeeList = new List<Employee>()
            {
                new Employee
                {
                    Id = 1,
                    FirstName = "Monkey D",
                    LastName = "Luffy",
                    Department = "Pirates",
                    Address = "Grand Line",
                    Email = "luffy@strawhats.com",
                    ContactNumber = "9878978977",
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Roronoa",
                    LastName = "Zoro",
                    Department = "Pirates",
                    Address = "Grand Line",
                    Email = "zoro@strawhats.com",
                    ContactNumber = "9878978978",
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Vinsmoke",
                    LastName = "Sanji",
                    Department = "Pirates",
                    Address = "Grand Line",
                    Email = "sanji@strawhats.com",
                    ContactNumber = "9878978979",
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                }
            };

            var testQuery = new GetAllEmployeesQuery();

            _mockQueryRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(expectedEmployeeList);

            //Act
            var result = await _getAllEmployeesHandler.Handle(testQuery, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Count, Is.EqualTo(expectedEmployeeList.Count));
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
