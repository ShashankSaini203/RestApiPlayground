using Dapper;
using Microsoft.Extensions.Configuration;
using RestApiPlayground.Domain.Repositories.Query.Base;
using RestApiPlayground.Infrastructure.Data;

namespace RestApiPlayground.Infrastructure.Repositories.Query.Base
{
    public class QueryRepository<T> : IQueryRepository<T> where T : class
    {
        public IDbConnector _dbConnector;

        public QueryRepository(IDbConnector dbConnector)
        {
            _dbConnector = dbConnector;           
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                var query = "SELECT * FROM EMPLOYEES";

                using (var connection = _dbConnector.CreateConnection())
                {
                    return (await connection.QueryAsync<T>(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
