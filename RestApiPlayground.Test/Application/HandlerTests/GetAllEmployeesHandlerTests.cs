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
            var resultList = result.ToList();
            // Assert
            Assert.NotNull(result);
            for (int i = 0; i < expectedEmployeeList.Count; i++)
            {
                Assert.That(resultList[i].Id, Is.EqualTo(expectedEmployeeList[i].Id.ToString()));
                Assert.That(resultList[i].FirstName, Is.EqualTo(expectedEmployeeList[i].FirstName));
                Assert.That(resultList[i].LastName, Is.EqualTo(expectedEmployeeList[i].LastName));
                Assert.That(resultList[i].Department, Is.EqualTo(expectedEmployeeList[i].Department));
                Assert.That(resultList[i].Address, Is.EqualTo(expectedEmployeeList[i].Address));
                Assert.That(resultList[i].Email, Is.EqualTo(expectedEmployeeList[i].Email));
                Assert.That(resultList[i].ContactNumber, Is.EqualTo(expectedEmployeeList[i].ContactNumber));
                Assert.That(resultList[i].CreationDate, Is.EqualTo(expectedEmployeeList[i].CreationDate));
                Assert.That(resultList[i].ModifiedDate, Is.EqualTo(expectedEmployeeList[i].ModifiedDate));
            }
        }
    }
}
