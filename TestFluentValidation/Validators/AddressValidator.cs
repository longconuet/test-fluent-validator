using FluentValidation;
using TestFluentValidation.Models;

namespace TestFluentValidation.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(address => address.Street)
                .NotEmpty()
                .WithMessage("Street is required");

            RuleFor(address => address.City)
              .NotEmpty()
              .WithMessage("City is required.");

            RuleFor(address => address.State)
              .NotEmpty()
              .WithMessage("State is required.");

            RuleFor(address => address.ZipCode)
              .NotEmpty()
              .Matches(@"^\d{5}(-\d{4})?$")
              .WithMessage("Invalid ZIP code.");
        }
    }
}
