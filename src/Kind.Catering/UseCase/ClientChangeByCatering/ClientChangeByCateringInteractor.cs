using System.Collections.Generic;
using System.Threading.Tasks;
using Kind.Catering.CrossCuttingConcerns.InternalException;
using Kind.Catering.Entity.DTO;
using Kind.Catering.Entity.DTO.ClientChangeByCatering;
using Kind.Catering.Infrastructure.Repository;

namespace Kind.Catering.UseCase.ClientChangeByCatering
{
    public class ClientChangeByCateringInteractor : IClientChangeByCateringUseCase
    {
        private readonly IClientCateringChangeHistoryRepository _repository;

        public ClientChangeByCateringInteractor(IClientCateringChangeHistoryRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Response<IEnumerable<ClientChangeByCateringResponse>>> Execute(ClientChangeByCateringRequest request)
        {
            if (request == null)
                throw new BadRequestException("ClientChangeByCatering request was null!");

            IEnumerable<ClientChangeByCateringResponse> result;
            if (request.CateringPointId.HasValue)
                result = await _repository.GetClientChangeByCatering(request.CateringPointId.Value);
            else
                result = await _repository.GetClientChangeByCateringAll();

            if(result == null)
                return Response<IEnumerable<ClientChangeByCateringResponse>>.FailedResponse("Client change by catering history not found!");
            return Response<IEnumerable<ClientChangeByCateringResponse>>.SuccessResponse(result);
        }
    }
}