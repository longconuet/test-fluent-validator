using FluentValidation;
using System.Text.RegularExpressions;
using TestFluentValidation.Models;

namespace TestFluentValidation.Validators
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(book => book.BookId)
              .NotEmpty()
              .Must(BeAValidBookId)
              .WithMessage("Invalid book ID format.");

            RuleFor(book => book.Title)
              .NotEmpty()
              .Length(2, 100);

            RuleFor(book => book.Author)
              .NotEmpty();

            // Conditional validation
            When(book => book.Title.Length > 50, () =>
            {
                RuleFor(book => book.Author)
                  .NotEmpty()
                  .WithMessage("Author is required for long titles.");
            });
        }

        private bool BeAValidBookId(string bookId)
        {
            if (string.IsNullOrWhiteSpace(bookId))
            {
                return false;
            }

            // Regular expression to match the format "Letter-Numbers"
            var regex = new Regex(@"^[A-Za-z]-\d+$");

            return regex.IsMatch(bookId);
        }
    }
}
