﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Kind.Catering.Entity.DTO;
using Kind.Catering.Entity.DTO.ClientChangeByCatering;

namespace Kind.Catering.UseCase.ClientChangeByCatering
{
    public interface IClientChangeByCateringUseCase
    {
        public Task<Response<IEnumerable<ClientChangeByCateringResponse>>> Execute(ClientChangeByCateringRequest request);
    }
}