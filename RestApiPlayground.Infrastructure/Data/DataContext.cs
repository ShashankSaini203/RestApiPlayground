using Microsoft.EntityFrameworkCore;
using RestApiPlayground.Domain.Contracts;

namespace RestApiPlayground.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
