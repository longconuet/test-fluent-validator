using FluentValidation;
using TestFluentValidation.Models;

namespace TestFluentValidation.Validators
{
    public class LibraryValidator : AbstractValidator<Library>
    {
        public LibraryValidator()
        {
            RuleFor(library => library.Name)
              .NotEmpty()
              .WithMessage("Library name is required.");

            RuleFor(library => library.Address)
              .SetValidator(new AddressValidator());

            RuleFor(library => library.PhoneNumber)
              .NotEmpty()
              .Matches(@"^\d{10}$")
              .WithMessage("Invalid phone number.");

            RuleFor(library => library.Email).EmailAddress();

            RuleFor(library => library.Books)
              .NotEmpty()
              .Must(b => b.Count >= 5)
              .WithMessage("At least 5 books are required.");

            RuleForEach(library => library.Books)
              .SetValidator(new BookValidator());
        }
    }
}
