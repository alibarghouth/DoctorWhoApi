namespace DoctorWho.Db.Reopsitories.AuthorRepository;

public interface IAuthorRepository
{
    Task<bool> IsAuthorExists(int authorId);
}
