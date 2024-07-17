using RestApiPlayground.Domain.Repositories.Command.Base;
using RestApiPlayground.Infrastructure.Data;

namespace RestApiPlayground.Infrastructure.Repositories.Command.Base
{
    public class CommandRepository<T> : ICommandRepository<T> where T : class
    {
        private readonly DataContext _dataContext;

        public CommandRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<T> CreateAsync(T entity)
        {
            try
            {
                await _dataContext.Set<T>().AddAsync(entity);
                await _dataContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteAsync(T entity)
        {
            try
            {
                _dataContext.Set<T>().Remove(entity);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
