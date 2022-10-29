using System.Collections.Generic;
using System.Threading.Tasks;
using Kind.Catering.Entity.DTO;
using Kind.Catering.UseCase.GetAllCaterings;
using Microsoft.AspNetCore.Mvc;

namespace Kind.Catering.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CateringController : ControllerBase
    {
        private readonly IGetAllCateringsUseCase _allCateringsUseCase;

        public CateringController(IGetAllCateringsUseCase allCateringsUseCase)
        {
            _allCateringsUseCase = allCateringsUseCase;
        }
        
        [HttpGet]
        public async Task<Response<IEnumerable<CateringPointDto>>> GetAllCateringPoints() 
            => await _allCateringsUseCase.Execute();
    }
}