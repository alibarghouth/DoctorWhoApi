using DoctorWho.Db.Model;

namespace DoctorWho.Web.Services.AuthorService
{
    public interface IAuthorService
    {
        Task<string> UpdateAuthorAsync(string authorName, int authorId);
    }
}
