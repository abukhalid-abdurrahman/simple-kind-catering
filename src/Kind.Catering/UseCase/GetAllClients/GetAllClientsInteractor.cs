using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kind.Catering.Entity.DTO;
using Kind.Catering.Infrastructure.Repository;

namespace Kind.Catering.UseCase.GetAllClients
{
    public class GetAllClientsInteractor : IGetAllClientsUseCase
    {
        private readonly IClientRepository _repository;

        public GetAllClientsInteractor(IClientRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Response<IEnumerable<ClientDto>>> Execute()
        {
            var allClients = (await _repository.GetAllClients());
            if(allClients == null)
                return Response<IEnumerable<ClientDto>>.FailedResponse("Clients list are null!");

            var result = allClients.Select(x => new ClientDto { ClientId = x.Id, ClientName = x.Name });
            return Response<IEnumerable<ClientDto>>.SuccessResponse(result);
        }
    }
}