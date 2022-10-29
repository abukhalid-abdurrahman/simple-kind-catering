using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kind.Catering.Entity.DTO;
using Kind.Catering.Infrastructure.Repository;

namespace Kind.Catering.UseCase.GetAllCaterings
{
    public class GetAllCateringsInteractor : IGetAllCateringsUseCase
    {
        private readonly ICateringPointRepository _repository;

        public GetAllCateringsInteractor(ICateringPointRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Response<IEnumerable<CateringPointDto>>> Execute()
        {
            var allCaterings = (await _repository.GetAllCateringPoints());
            if(allCaterings == null)
                return Response<IEnumerable<CateringPointDto>>.FailedResponse("Catering Points list are null!");

            var result = allCaterings.Select(x => new CateringPointDto { CateringPointId = x.Id, CateringPointName = x.Name });
            return Response<IEnumerable<CateringPointDto>>.SuccessResponse(result);
        }
    }
}