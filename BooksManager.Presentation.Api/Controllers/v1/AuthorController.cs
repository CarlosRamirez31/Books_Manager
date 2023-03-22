using Application.Feautres.Authors.Commands.CreateAuthorCommand;
using Application.Feautres.Authors.Commands.DeleteAuthorCoomand;
using Application.Feautres.Authors.Commands.UpdateAuthorCommand;
using BooksManager.Core.Application.Feautres.Authors.Queries.GetAllAuthor;
using BooksManager.Core.Application.Feautres.Authors.Queries.GetAuthorById;
using BooksManager.Core.Application.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class AuthorController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] GetAllAuthorQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetAuthorByIdQuery() { AuthorId = id}));
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(CreateAuthorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update(UpdateAuthorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteAuthorCommand() { AuthorId = id }));
        }
    }
}
