using Dapper;
using Microsoft.Extensions.Configuration;
using RestApiPlayground.Domain.Contracts;
using RestApiPlayground.Domain.Repositories.Query;
using RestApiPlayground.Infrastructure.Repositories.Query.Base;
using System.Data;

namespace RestApiPlayground.Infrastructure.Repositories.Query
{
    public class EmployeeQueryRepository : QueryRepository<Employee>, IEmployeeQueryRepository
    {
        public EmployeeQueryRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<Employee> GetByIdAsync(long id)
        {
            try
            {
                var query = "SELECT * FROM EMPLOYEES WHERE ID = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int64);

                using (var connection = CreateConnection())
                {
                    return await connection.QueryFirstOrDefaultAsync<Employee>(query, parameters);
                }

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
    }
}
