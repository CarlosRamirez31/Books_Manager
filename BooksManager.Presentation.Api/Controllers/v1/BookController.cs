using Api.Controllers;
using BooksManager.Core.Application.Feautres.Books.Commands.CreateBookCommand;
using BooksManager.Core.Application.Feautres.Books.Commands.DeleteBookCommand;
using BooksManager.Core.Application.Feautres.Books.Queries.GetAllBook;
using BooksManager.Core.Application.Feautres.Books.Queries.GetBookById;
using BooksManager.Core.Application.Feautres.Books.Queries.GetFilterBook;
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

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetBookByIdQuery() { BookId = id }));
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(CreateBookCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteBookCommand() { BookId = id }));
        }
    }
}
