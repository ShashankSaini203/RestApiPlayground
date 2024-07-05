using Microsoft.EntityFrameworkCore;
using RestApiPlayground.Domain.Repositories.Base;
using RestApiPlayground.Infrastructure.Data;

namespace RestApiPlayground.Infrastructure.Repositories.Command.Base
{
    public class CommandRepository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _dataContext;

        public CommandRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            _dataContext.Set<T>().AsNoTracking();
            return await _dataContext.Set<T>().ToListAsync();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dataContext.Set<T>().AddAsync(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dataContext.Set<T>().Update(entity);
            await _dataContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dataContext.Set<T>().Remove(entity);
            await _dataContext.SaveChangesAsync();
        }
    }
}
