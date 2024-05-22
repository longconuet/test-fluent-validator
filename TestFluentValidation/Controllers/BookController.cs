using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestFluentValidation.Models;
using TestFluentValidation.Validators;

namespace TestFluentValidation.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {

        [HttpPost("create")]
        public async Task<ActionResult> CreateBook([FromBody] Book book)
        {
            var validator = new BookValidator();
            var results = validator.Validate(book);

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    Console.WriteLine($"Error: {failure.ErrorMessage}");
                }

                throw new ValidationException("Validation failed for the book object.");
            }

            return Ok();
        }
    }
}
