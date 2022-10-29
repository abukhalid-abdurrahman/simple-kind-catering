using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Kind.Catering.CrossCuttingConcerns.Configs;
using Kind.Catering.Entity.Model;
using Kind.Catering.Infrastructure.Repository;
using Npgsql;

namespace Kind.Catering.Infrastructure.PostgresSqlRepository
{
    public sealed class ClientRepository : IClientRepository
    {
        private readonly CateringDbConfig _cateringDbConfig;

        public ClientRepository(CateringDbConfig cateringDbConfig)
        {
            _cateringDbConfig = cateringDbConfig;
        }

        public async Task<IEnumerable<Client>> GetAllClients()
        {
            await using var connection = new NpgsqlConnection(_cateringDbConfig.ConnectionString);
            const string query = "SELECT * FROM client;";
            return await connection.QueryAsync<Client>(query);
        }
    }
}