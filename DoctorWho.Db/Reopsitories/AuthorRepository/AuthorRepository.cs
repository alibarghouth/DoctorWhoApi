using DoctorWho.Db.Context;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Reopsitories.AuthorRepository;

public sealed class AuthorRepository : IAuthorRepository
{
    private readonly ApplicationDbContext _context;

    public AuthorRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AuthorIsExists(int authorId)
    {
        return await _context.Authors
            .AnyAsync(x => x.Id == authorId);
    }
}
