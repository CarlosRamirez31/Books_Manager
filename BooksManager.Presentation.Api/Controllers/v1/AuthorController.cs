using Application.Features.Authors.Commands.CreateAuthorCommand;
using Application.Features.Authors.Commands.DeleteAuthorCoomand;
using Application.Features.Authors.Commands.UpdateAuthorCommand;
using BooksManager.Core.Application.Features.Authors.Queries.GetAllAuthor;
using BooksManager.Core.Application.Features.Authors.Queries.GetAuthorById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class AuthorController : BaseApiController
    {
        [HttpGet()]
        public async Task<ActionResult> GetFilter([FromQuery] GetFilterAuthorQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("All")]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllAuthorQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetAuthorByIdQuery() { AuthorId = id}));
        }

        [HttpPost("Register")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Register(CreateAuthorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("Update")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Update(UpdateAuthorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteAuthorCommand() { AuthorId = id }));
        }
    }
}
