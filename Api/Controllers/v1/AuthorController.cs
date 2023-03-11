using Application.Feautres.Authors.Commands.CreateAuthorCommand;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class AuthorController : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult> Register(CreateAuthorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
