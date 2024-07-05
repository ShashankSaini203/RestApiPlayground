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
            return null;
        }
    }
}
