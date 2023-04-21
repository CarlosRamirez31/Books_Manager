using Api.Controllers;
using BooksManager.Core.Application.Dtos.Users;
using BooksManager.Core.Application.Features.Users.Commands.AutenticateCommand;
using BooksManager.Core.Application.Features.Users.Commands.RegisterCommand;
using Microsoft.AspNetCore.Mvc;

namespace BooksManager.Presentation.Api.Controllers
{
    [Route("api/Account")]
    [ApiController]
    public class AccountController : BaseApiController
    {
        [HttpPost("Authenticate")]
        public async Task<ActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await Mediator.Send(new AuthenticateCommand
            {
                Email = request.Email,
                Password = request.Password,
                IpAddress = GenerateIpAddress()
            }));
        }

        [HttpPost("Register")]
        public async Task<ActionResult> RegisterAsync(RegisterRequest request)
        {
            return Ok(await Mediator.Send(new RegisterCommand
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.UserName,
                Password = request.Password,
                ConfirmPassword = request.ConfirmPassword,
                Origin = Request.Headers["origin"]
            })) ;
        }

        private string GenerateIpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["XX-Forwarded-For"];
            else
                return HttpContext.Connection.LocalIpAddress!.MapToIPv4().ToString();

        }
    }
}
