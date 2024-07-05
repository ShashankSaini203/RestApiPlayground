using RestApiPlayground.Infrastructure.Data;
using System;

namespace RestApiPlayground.Infrastructure.Repositories.Query.Base
{
    public class QueryRepository
    {


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            _dataContext.Set<T>().AsNoTracking();
            return await _dataContext.Set<T>().ToListAsync();
        }
    }
}
