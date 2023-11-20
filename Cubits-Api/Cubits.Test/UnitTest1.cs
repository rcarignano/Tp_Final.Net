using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Cubits.Application.Contracts.GetClient;
using Cubits.Application.Exceptions;
using Cubits.Application.Handlers;
using Cubits.Application.Models;
using Cubits.Domain.Entities;
using Cubits.Domain.Ports;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using Xunit;

namespace Cubits.Tests.Application.Handlers
{
    public class GetClientHandlerTests
    {
        private GetClientHandler _handler;
        private Mock<IMapper> _mapperMock;
        private Mock<IClientRepository> _clientRepositoryMock;
        private Mock<IValidator<GetClientRequest>> _validatorMock;

        public GetClientHandlerTests()
        {
            _validatorMock = new Mock<IValidator<GetClientRequest>>();
            _clientRepositoryMock = new Mock<IClientRepository>();
            _mapperMock = new Mock<IMapper>();

            _handler = new GetClientHandler(
                _clientRepositoryMock.Object,
                _mapperMock.Object,
                _validatorMock.Object
            );
        }

        [Fact]
        public async Task GetClientHandler_ValidRequest_ReturnsValidResponse()
        {
            //Meto los objetos simulados
            var request = new GetClientRequest { ClientId = 1 };
            var validationResult = new ValidationResult();

            _validatorMock.Setup(v => v.Validate(request)).Returns(validationResult);

            var existingClient = new Client();
            _clientRepositoryMock.Setup(r => r.Get(request.ClientId)).ReturnsAsync(existingClient);

            _mapperMock.Setup(m => m.Map<ClientDto>(existingClient)).Returns(new ClientDto());

            var result = await _handler.Handle(request, CancellationToken.None);

            //Para un resultado no nulo,ademas de la prop no nula 
            Assert.NotNull(result);
            Assert.NotNull(result.Client);
        }

        [Fact]
        public async Task GetClientHandler_InvalidRequest_ThrowsValidationException()
        {
            var request = new GetClientRequest { ClientId = 1 };
            var validationResult = new ValidationResult();
            validationResult.Errors.Add(new ValidationFailure("Property", "Error_message"));

            _validatorMock.Setup(v => v.Validate(request)).Returns(validationResult);

            //Para ver que una splic invalida genere una validacion
            await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(request, CancellationToken.None));
        }

        [Fact]
        public async Task GetClientHandler_NonexistentClient_ThrowsNotFoundException()
        {
            var request = new GetClientRequest { ClientId = 1 };
            var validationResult = new ValidationResult();

            _validatorMock.Setup(v => v.Validate(request)).Returns(validationResult);
            _clientRepositoryMock.Setup(r => r.Get(request.ClientId)).ReturnsAsync((Client)null);

            //Una exepcion de not found
            await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(request, CancellationToken.None));
        }
    }
}
