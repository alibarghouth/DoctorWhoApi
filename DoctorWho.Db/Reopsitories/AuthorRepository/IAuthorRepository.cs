namespace DoctorWho.Db.Reopsitories.AuthorRepository;

public interface IAuthorRepository
{
    Task<bool> AuthorIsExists(int authorId);
}
