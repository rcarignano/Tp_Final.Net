using AutoMapper;
using Cubits.Application.Contracts.GetClientList;
using Cubits.Application.Models;
using Cubits.Domain.Entities;
using Cubits.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubits.Application.Handlers
{
    public class GetClientListHandler : IRequestHandler<GetClientListRequest, GetClientListResponse>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public GetClientListHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<GetClientListResponse> Handle(GetClientListRequest request, CancellationToken cancellationToken)
        {
            var response= new GetClientListResponse();
            var clientList = await _clientRepository.GetList();
            response.ClientList=clientList
                .Select(MapTo)
                .ToList();

            return response;
        }

        private ClientDto MapTo(Client? client)
        {
            return _mapper.Map<ClientDto>(client);
        }
    }
}
