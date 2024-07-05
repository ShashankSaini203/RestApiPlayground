using Dapper;
using Microsoft.Extensions.Configuration;
using RestApiPlayground.Domain.Repositories.Query.Base;
using RestApiPlayground.Infrastructure.Data;

namespace RestApiPlayground.Infrastructure.Repositories.Query.Base
{
    public class QueryRepository<T> : DbConnector, IQueryRepository<T> where T : class
    {
        public QueryRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                var query = "SELECT * FROM EMPLOYEES";

                using (var connection = CreateConnection())
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
