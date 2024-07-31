using System.Data;

namespace RestApiPlayground.Infrastructure.Data
{
    public interface IDbConnector
    {
        IDbConnection CreateConnection();

        string GetConnection();
    }
}
