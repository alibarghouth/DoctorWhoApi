using DoctorWho.Db.Reopsitories.AuthorRepository;
using DoctorWho.Web.DTOs.AuthorDTOs;
using DoctorWho.Web.Exceptions;
using Mapster;

namespace DoctorWho.Web.Services.AuthorService
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> UpdateAuthor(string authorName, int authorId)
        {
            var author = await _authorRepository.FindAuthor(authorId)
                ?? throw new DoctorWhoNotFound("author not found");
            author.Name = authorName;

            await _authorRepository.UpdateAuthor(author);

            return (author.Adapt<Author>());
        }
    }
}
