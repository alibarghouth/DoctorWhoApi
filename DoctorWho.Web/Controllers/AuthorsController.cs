using DoctorWho.Web.Services.AuthorService;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpPut("update_author/{authorId:int}")]
        public async Task<IActionResult> UpdateAuthorAsync(string authorId, int AuthorId)
        {
            return Ok(await _authorService.UpdateAuthorAsync(authorId, AuthorId));
        }
    }
}
