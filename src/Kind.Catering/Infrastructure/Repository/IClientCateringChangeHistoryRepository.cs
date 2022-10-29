using System.Collections.Generic;
using System.Threading.Tasks;
using Kind.Catering.Entity.DTO.CateringChangeByClient;
using Kind.Catering.Entity.DTO.ClientChangeByCatering;

namespace Kind.Catering.Infrastructure.Repository
{
    public interface IClientCateringChangeHistoryRepository
    {
        public Task<IEnumerable<CateringChangeByClientResponse>> GetCateringChangeByClientAll();
        public Task<IEnumerable<CateringChangeByClientResponse>> GetCateringChangeByClient(long clientId);
        
        public Task<IEnumerable<ClientChangeByCateringResponse>> GetClientChangeByCateringAll();
        public Task<IEnumerable<ClientChangeByCateringResponse>> GetClientChangeByCatering(long cateringId);
    }
}