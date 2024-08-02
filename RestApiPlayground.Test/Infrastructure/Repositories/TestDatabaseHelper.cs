using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using RestApiPlayground.Domain.Contracts;
using RestApiPlayground.Infrastructure.Data;

namespace RestApiPlayground.Test.Infrastructure.Repositories
{
    [SetUpFixture]
    public static class TestDatabaseHelper
    {
        public static DataContext DbContext { get; private set; }
        public static List<Employee> Employees { get; private set; }
        public static SqliteConnection SharedConnection { get; private set; }

        [OneTimeSetUp]
        public static void SetupTestDatabase()
        {
            Employees = createTestEmployees();

            SharedConnection = new SqliteConnection("DataSource=:memory:");
            SharedConnection.Open();

            // Use SQLite In-Memory Database
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseSqlite(SharedConnection)
            .Options;

            DbContext = new DataContext(options);

            // Ensure the database is created
            DbContext.Database.OpenConnection();
            DbContext.Database.EnsureCreated();

            // Seed the database with test data
            DbContext.Employees.AddRange(Employees);
            DbContext.SaveChanges();
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            DbContext.Database.CloseConnection();
            DbContext.Dispose();
            SharedConnection.Close();
        }

        public static List<Employee> createTestEmployees() => new List<Employee>()
        {
            Employee.CreateEmployee(1, "TestFirstName1", "TestLastName1", "TestAddress1", "TestDepartment1", "TestContactNumber1", "TestEmail1"),
            Employee.CreateEmployee(2, "TestFirstName2", "TestLastNWame2", "TestAddress2", "TestDepartment2", "TestContactNumber2", "TestEmail2"),
            Employee.CreateEmployee(3, "TestFirstName3", "TestLastName3", "TestAddress3", "TestDepartment3", "TestContactNumber3", "TestEmail3")
        };
    }
}
