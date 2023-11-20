using AutoMapper;
using Cubits.Application.Contracts.GetClient;
using Cubits.Application.Exceptions;
using Cubits.Application.Models;
using Cubits.Application.Validators;
using Cubits.Domain.Ports;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cubits.Application.Handlers
{
    public class GetClientHandler : IRequestHandler<GetClientRequest, GetClientResponse>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<GetClientRequest> _validator;

        public GetClientHandler(IClientRepository clientRepository, IMapper mapper, IValidator<GetClientRequest> validator)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public async Task<GetClientResponse> Handle(GetClientRequest request, CancellationToken cancellationToken)
        {
            var response = new GetClientResponse();

            var validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var client = await _clientRepository.Get(request.ClientId);

            if (client == null)
            {
                throw new NotFoundException();
            }

            response.Client = _mapper.Map<ClientDto>(client);

            return response;
        }
    }
}
