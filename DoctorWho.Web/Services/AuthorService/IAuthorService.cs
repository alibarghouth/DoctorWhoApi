using DoctorWho.Web.DTOs.AuthorDTOs;

namespace DoctorWho.Web.Services.AuthorService
{
    public interface IAuthorService
    {
        Task<Author> UpdateAuthor(string authorName, int authorId);
    }
}
