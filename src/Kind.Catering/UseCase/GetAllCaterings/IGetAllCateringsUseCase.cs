using System.Collections.Generic;
using System.Threading.Tasks;
using Kind.Catering.Entity.DTO;

namespace Kind.Catering.UseCase.GetAllCaterings
{
    public interface IGetAllCateringsUseCase
    {
        public Task<Response<IEnumerable<CateringPointDto>>> Execute();
    }
}