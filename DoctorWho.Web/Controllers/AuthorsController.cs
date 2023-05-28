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
        [HttpPut("{authorId:int}")]
        public async Task<IActionResult> UpdateAuthor(string authorName, int authorId)
        {
            return Ok(await _authorService.UpdateAuthor(authorName, authorId));
        }
    }
}
