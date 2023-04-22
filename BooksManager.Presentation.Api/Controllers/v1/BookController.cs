using Api.Controllers;
using BooksManager.Core.Application.Features.Books.Commands.CreateBookCommand;
using BooksManager.Core.Application.Features.Books.Commands.DeleteBookCommand;
using BooksManager.Core.Application.Features.Books.Commands.UpdateBookCommand;
using BooksManager.Core.Application.Features.Books.Queries.GetAllBook;
using BooksManager.Core.Application.Features.Books.Queries.GetBookById;
using BooksManager.Core.Application.Features.Books.Queries.GetFilterBook;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksManager.Presentation.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class BookController : BaseApiController 
    {
        [HttpGet]
        public async Task<ActionResult> List([FromQuery] GetFilterBookQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("All")]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllBookQuery()));
        }

        [HttpGet("{bookId}")]
        public async Task<ActionResult> GetById(int bookId)
        {
            return Ok(await Mediator.Send(new GetBookByIdQuery() { BookId = bookId }));
        }

        [HttpPost("Register")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Register(CreateBookCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("Update/{bookId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Update(int bookId, UpdateBookCommand command)
        {
            if (bookId != command.BookId)
                return BadRequest("Los parametros de bookId no coinciden");

            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("Delete/{bookId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int bookId)
        {
            return Ok(await Mediator.Send(new DeleteBookCommand() { BookId = bookId }));
        }
    }
}
