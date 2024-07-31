using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace RestApiPlayground.Infrastructure.Data
{
    public class DbConnector : IDbConnector
    {
        private readonly IConfiguration _configuration;

        public DbConnector(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public virtual IDbConnection CreateConnection()
        {
            var connectionString = GetConnection();
            return new SqliteConnection(connectionString);
        }

        public virtual string GetConnection()
        {
            return _configuration.GetConnectionString("DefaultConnection") ?? throw new NullReferenceException();
        }
    }
}
