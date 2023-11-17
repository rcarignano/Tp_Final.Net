using Cubits.Application.Contracts.GetClient;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubits.Application.Validators
{
    public class GetClientRequestValidator : AbstractValidator<GetClientRequest>
    {
        public GetClientRequestValidator()
        {
            RuleFor(x => x.ClientId)
                .NotEmpty().WithMessage("GetClient.IsNull")
                .GreaterThan(0).WithMessage("El ID del cliente debe ser mayor que cero.");
        }
    }
}
