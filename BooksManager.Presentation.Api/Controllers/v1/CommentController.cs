using Api.Controllers;
using BooksManager.Core.Application.Feautres.Comments.Commands.CreateCommentCommand;
using BooksManager.Core.Application.Feautres.Comments.Commands.DeleteCommentCommand;
using BooksManager.Core.Application.Feautres.Comments.Commands.UpdateCommentCommand;
using Microsoft.AspNetCore.Mvc;

namespace BooksManager.Presentation.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Book/{bookId}/Comment")]
    public class CommentController : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult> Register(int bookId, CreateCommentCommand command)
        {
            if (bookId != command.BookId)
                return BadRequest("Los parametro bookId son diferente");

            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<ActionResult> Update(int bookId, UpdateCommentCommand command)
        {
            if (bookId != command.BookId)
                return BadRequest("Los parametro bookId son diferente");

            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int bookId, DeleteCommentCommand command)
        {
            if (bookId != command.BookId)
                return BadRequest("Los parametro bookId son diferente");

            return Ok(await Mediator.Send(command));
        }
    }
}
