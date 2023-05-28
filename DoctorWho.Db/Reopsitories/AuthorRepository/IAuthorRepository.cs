using DoctorWho.Db.Model;

namespace DoctorWho.Db.Reopsitories.AuthorRepository
{
    public interface IAuthorRepository
    {
        Task<Author> UpdateAuthor(Author author);
        Task<Author?> FindAuthor(int authorId);
        Task<bool> IsAuthorExists(int authorId);
    }
}