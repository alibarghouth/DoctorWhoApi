namespace DoctorWho.Web.Services.AuthorService
{
    public interface IAuthorService
    {
        Task<string> UpdateAuthor(string authorName, int authorId);
    }
}
