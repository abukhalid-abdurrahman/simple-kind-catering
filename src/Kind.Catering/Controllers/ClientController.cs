using System.Collections.Generic;
using System.Threading.Tasks;
using Kind.Catering.Entity.DTO;
using Kind.Catering.UseCase.GetAllClients;
using Microsoft.AspNetCore.Mvc;

namespace Kind.Catering.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IGetAllClientsUseCase _allClientsUse;

        public ClientController(IGetAllClientsUseCase allClientsUse)
        {
            _allClientsUse = allClientsUse;
        }
        
        [HttpGet]
        public async Task<Response<IEnumerable<ClientDto>>> GetAllClients() => await _allClientsUse.Execute();
    }
}