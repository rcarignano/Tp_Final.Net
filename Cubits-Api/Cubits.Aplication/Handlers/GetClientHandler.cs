using AutoMapper;
using Cubits.Application.Contracts.GetClient;
using Cubits.Application.Exceptions;
using Cubits.Application.Models;
using Cubits.Application.Validators;
using Cubits.Domain.Ports;
using MediatR;

namespace Cubits.Application.Handlers
{
    internal class GetClientHandler : IRequestHandler<GetClientRequest, GetClientResponse>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public GetClientHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<GetClientResponse> Handle(GetClientRequest request, CancellationToken cancellationToken)
        {
            var response = new GetClientResponse();
            var client = await _clientRepository.Get(request.ClientId);
            if (client == null)
                throw new NotFoundExeption();
            response.Client = _mapper.Map<ClientDto>(client);
            return response;

        }
    }
}
