﻿using Microsoft.Data.Sqlite;
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
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            return new SqliteConnection(connectionString);
        }
    }
}
