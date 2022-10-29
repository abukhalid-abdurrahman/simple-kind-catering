using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Kind.Catering.CrossCuttingConcerns.Configs;
using Kind.Catering.Entity.DTO.CateringChangeByClient;
using Kind.Catering.Entity.DTO.ClientChangeByCatering;
using Kind.Catering.Infrastructure.Repository;
using Npgsql;

namespace Kind.Catering.Infrastructure.PostgresSqlRepository
{
    public sealed class ClientCateringChangeHistoryRepository : IClientCateringChangeHistoryRepository
    {
        private readonly CateringDbConfig _cateringDbConfig;

        public ClientCateringChangeHistoryRepository(CateringDbConfig cateringDbConfig)
        {
            _cateringDbConfig = cateringDbConfig;
        }

        public async Task<IEnumerable<CateringChangeByClientResponse>> GetCateringChangeByClientAll()
        {
            await using var connection = new NpgsqlConnection(_cateringDbConfig.ConnectionString);
            var result = await connection.QueryAsync<CateringChangeByClientResponse>(
                "catering_change_by_client_history_all_fn",
                commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<IEnumerable<CateringChangeByClientResponse>> GetCateringChangeByClient(long clientId)
        {
            await using var connection = new NpgsqlConnection(_cateringDbConfig.ConnectionString);
            var result = await connection.QueryAsync<CateringChangeByClientResponse>(
                "catering_change_by_client_history_fn",
                new { client_id_in = clientId },
                commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<IEnumerable<ClientChangeByCateringResponse>> GetClientChangeByCateringAll()
        {
            await using var connection = new NpgsqlConnection(_cateringDbConfig.ConnectionString);
            var result = await connection.QueryAsync<ClientChangeByCateringResponse>(
                "client_change_by_catering_history_all_fn",
                commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<IEnumerable<ClientChangeByCateringResponse>> GetClientChangeByCatering(long cateringId)
        {
            await using var connection = new NpgsqlConnection(_cateringDbConfig.ConnectionString);
            var result = await connection.QueryAsync<ClientChangeByCateringResponse>(
                "client_change_by_catering_history_fn",
                new { catering_id_in = cateringId },
                commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}