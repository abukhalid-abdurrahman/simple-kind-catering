using System.Collections.Generic;
using System.Threading.Tasks;
using Kind.Catering.Entity.Model;

namespace Kind.Catering.Infrastructure.Repository
{
    public interface ICateringPointRepository
    {
        public Task<IEnumerable<CateringPoint>> GetAllCateringPoints();
    }
}