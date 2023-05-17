using DoctorWho.Db.Model;

namespace DoctorWho.Db.Reopsitories.AuthorRepository
{
    public interface IAuthorRepository
    {
        Task<Author> UpdateAuthorAsync(Author author);
        Task<Author> FindAuthorAsync(int id);
    }
}
