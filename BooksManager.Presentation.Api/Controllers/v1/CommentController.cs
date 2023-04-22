using Api.Controllers;
using BooksManager.Core.Application.Features.Comments.Commands.CreateCommentCommand;
using BooksManager.Core.Application.Features.Comments.Commands.DeleteCommentCommand;
using BooksManager.Core.Application.Features.Comments.Commands.UpdateCommentCommand;
using BooksManager.Core.Application.Features.Comments.Queries.GetCommentByBookId;
using Microsoft.AspNetCore.Mvc;

namespace BooksManager.Presentation.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Book/{bookId}/Comment")]
    public class CommentController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult> GetByBook(int bookId)
        {
            return Ok(await Mediator.Send(new GetCommentByBookIdQuery() { BookId = bookId}));
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(int bookId, CreateCommentCommand command)
        {
            if (bookId != command.BookId)
                return BadRequest("Los parametro bookId son diferente");

            return Ok(await Mediator.Send(command));
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update(int bookId, UpdateCommentCommand command)
        {
            if (bookId != command.BookId)
                return BadRequest("Los parametro bookId son diferente");

            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(int bookId, DeleteCommentCommand command)
        {
            if (bookId != command.BookId)
                return BadRequest("Los parametro bookId son diferente");

            return Ok(await Mediator.Send(command));
        }
    }
}
