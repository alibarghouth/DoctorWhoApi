using DoctorWho.Db.Reopsitories.AuthorRepository;
using DoctorWho.Web.Exceptions;
using System.Net;

namespace DoctorWho.Web.Services.AuthorService
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<string> UpdateAuthorAsync(string authorName, int authorId)
        {
            if(authorId == 0)
            {
                throw new DoctorWhoExceptions
                {
                    Message = "the author is not exists",
                    StatusCode = HttpStatusCode.BadRequest,
                };
            }
            var author = await _authorRepository.FindAuthorAsync(authorId);
            if(author is null)
            {
                throw new DoctorWhoExceptions
                {
                    Message = "the author is not exists",
                    StatusCode = HttpStatusCode.BadRequest,
                };
            }
            if (!string.IsNullOrEmpty(authorName))
            {
                author.Name = authorName;
            }
            await _authorRepository.UpdateAuthorAsync(author);

            return authorName;
        }
    }
}
