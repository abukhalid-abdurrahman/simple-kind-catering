using System.Collections.Generic;
using System.Threading.Tasks;
using Kind.Catering.CrossCuttingConcerns.InternalException;
using Kind.Catering.Entity.DTO;
using Kind.Catering.Entity.DTO.CateringChangeByClient;
using Kind.Catering.Infrastructure.Repository;

namespace Kind.Catering.UseCase.CateringChangeByClient
{
    public sealed class CateringChangeByClientInteractor : ICateringChangeByClientUseCase
    {
        private readonly IClientCateringChangeHistoryRepository _repository;

        public CateringChangeByClientInteractor(IClientCateringChangeHistoryRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Response<IEnumerable<CateringChangeByClientResponse>>> Execute(CateringChangeByClientRequest request)
        {
            if (request == null)
                throw new BadRequestException("CateringChangeByClientRequest request was null!");

            IEnumerable<CateringChangeByClientResponse> result;
            if (request.ClientId.HasValue)
                result = await _repository.GetCateringChangeByClient(request.ClientId.Value);
            else
                result = await _repository.GetCateringChangeByClientAll();

            if(result == null)
                return Response<IEnumerable<CateringChangeByClientResponse>>.FailedResponse("Client change by catering history not found!");
            return Response<IEnumerable<CateringChangeByClientResponse>>.SuccessResponse(result);
        }
    }
}