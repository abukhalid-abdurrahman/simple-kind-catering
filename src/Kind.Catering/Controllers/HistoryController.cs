using System.Collections.Generic;
using System.Threading.Tasks;
using Kind.Catering.Entity.DTO;
using Kind.Catering.Entity.DTO.CateringChangeByClient;
using Kind.Catering.Entity.DTO.ClientChangeByCatering;
using Kind.Catering.UseCase.CateringChangeByClient;
using Kind.Catering.UseCase.ClientChangeByCatering;
using Microsoft.AspNetCore.Mvc;

namespace Kind.Catering.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoryController : ControllerBase
    {
        private readonly ICateringChangeByClientUseCase _changeByClientUseCase;
        private readonly IClientChangeByCateringUseCase _changeByCateringUseCase;

        public HistoryController(
            ICateringChangeByClientUseCase changeByClientUseCase,
            IClientChangeByCateringUseCase changeByCateringUseCase)
        {
            _changeByClientUseCase = changeByClientUseCase;
            _changeByCateringUseCase = changeByCateringUseCase;
        }
        
        [HttpGet("ChangeByClient")]
        public async Task<Response<IEnumerable<CateringChangeByClientResponse>>> GetChangeByClient([FromQuery] long? clientId)
        {
            return await _changeByClientUseCase.Execute(new() { ClientId = clientId });
        }
        
        [HttpGet("ChangeByCatering")]
        public async Task<Response<IEnumerable<ClientChangeByCateringResponse>>> GetChangeByCatering([FromQuery] long? cateringId)
        {
            return await _changeByCateringUseCase.Execute(new() { CateringPointId = cateringId });
        }
    }
}