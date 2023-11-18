using Cubits.Application.Contracts.GetClient;
using FluentValidation;

namespace Cubits.Application.Validators
{
    public class GetClientRequestValidator : AbstractValidator<GetClientRequest>
    {
        public GetClientRequestValidator()
        {
            RuleFor(x => x.ClientId)
                .NotEmpty().WithMessage("GetClient.IsNull")
                .GreaterThan(0).WithMessage("El ID del cliente debe ser mayor que cero.")
                .Must(BeetweenValues).WithMessage("El ID del cliente no se encuentra dentro de los permitidos por la base.");
        }

        private bool BeetweenValues(int clientId)
        {
            int[] allowedValues = { 1, 2, 3, 4, 5 };
            return allowedValues.Contains(clientId);
        }
    }
}
