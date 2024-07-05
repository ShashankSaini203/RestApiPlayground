namespace RestApiPlayground.Domain.Repositories.Query.Base
{
    public interface IQueryRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
    }
}
