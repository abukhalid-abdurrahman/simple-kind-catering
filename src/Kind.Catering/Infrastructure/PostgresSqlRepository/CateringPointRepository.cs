using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Kind.Catering.CrossCuttingConcerns.Configs;
using Kind.Catering.Entity.Model;
using Kind.Catering.Infrastructure.Repository;
using Npgsql;

namespace Kind.Catering.Infrastructure.PostgresSqlRepository
{
    public sealed class CateringPointRepository : ICateringPointRepository
    {
        private readonly CateringDbConfig _cateringDbConfig;

        public CateringPointRepository(CateringDbConfig cateringDbConfig)
        {
            _cateringDbConfig = cateringDbConfig;
        }

        public async Task<IEnumerable<CateringPoint>> GetAllCateringPoints()
        {
            await using var connection = new NpgsqlConnection(_cateringDbConfig.ConnectionString);
            const string query = "SELECT * FROM catering_point;";
            return await connection.QueryAsync<CateringPoint>(query);
        }
    }
}