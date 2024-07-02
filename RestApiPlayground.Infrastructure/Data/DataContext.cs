using Microsoft.EntityFrameworkCore;
using RestApiPlayground.Domain.Contracts;

namespace RestApiPlayground.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.ModifiedDate)
                .HasDefaultValueSql("GETDATE()"); 
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
