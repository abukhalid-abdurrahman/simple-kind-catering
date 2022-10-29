using System.Threading.Tasks;
using Kind.Catering.Entity.DTO;
using Kind.Catering.Entity.DTO.CateringChangeByClient;

namespace Kind.Catering.UseCase.CateringChangeByClient
{
    public sealed class CateringChangeByClientInteractor : ICateringChangeByClientUseCase
    {
        public async Task<Response<CateringChangeByClientResponse>> Execute(CateringChangeByClientRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}