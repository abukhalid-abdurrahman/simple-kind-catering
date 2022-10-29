using System.Collections.Generic;
using System.Threading.Tasks;
using Kind.Catering.Entity.DTO;

namespace Kind.Catering.UseCase.GetAllClients
{
    public interface IGetAllClientsUseCase
    {
        public Task<Response<IEnumerable<ClientDto>>> Execute();
    }
}