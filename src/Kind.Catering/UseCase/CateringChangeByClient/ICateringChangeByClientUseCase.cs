using System.Collections.Generic;
using System.Threading.Tasks;
using Kind.Catering.Entity.DTO;
using Kind.Catering.Entity.DTO.CateringChangeByClient;

namespace Kind.Catering.UseCase.CateringChangeByClient
{
    public interface ICateringChangeByClientUseCase
    {
        public Task<Response<IEnumerable<CateringChangeByClientResponse>>> Execute(CateringChangeByClientRequest request);
    }
}