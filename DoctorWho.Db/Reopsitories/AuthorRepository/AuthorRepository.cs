using DoctorWho.Db.Context;
using DoctorWho.Db.Model;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Reopsitories.AuthorRepository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AuthorRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Author> UpdateAuthor(Author author)
        {
            _dbContext.Authors.Update(author);
            await _dbContext.SaveChangesAsync();
            return author;
        }

        public async Task<Author?> FindAuthor(int authorId)
        {
            return await _dbContext.Authors.FindAsync(authorId);
        }

        public async Task<bool> IsAuthorExists(int authorId)
        {
           return await _dbContext.Authors
                .AsNoTracking()
                .AnyAsync(x => x.Id == authorId);
        }
    }
}