using DoctorWho.Db.Context;
using DoctorWho.Db.Model;

namespace DoctorWho.Db.Reopsitories.AuthorRepository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AuthorRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Author> UpdateAuthorAsync(Author author)
        {
            _dbContext.Authors.Update(author);
            await _dbContext.SaveChangesAsync();
            return author;
        }

        public async Task<Author> FindAuthorAsync(int id)
        {
            return await _dbContext.Authors.FindAsync(id);
        }
    }
}
