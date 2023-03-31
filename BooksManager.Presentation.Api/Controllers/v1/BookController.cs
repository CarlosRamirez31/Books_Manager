using Api.Controllers;
using BooksManager.Core.Application.Feautres.Books.Queries.GetAllBook;
using Microsoft.AspNetCore.Mvc;

namespace BooksManager.Presentation.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class BookController : BaseApiController 
    {
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllBookQuery()));
        }
    }
}
