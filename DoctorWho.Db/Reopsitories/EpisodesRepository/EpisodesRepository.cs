using DoctorWho.Db.Context;
using DoctorWho.Db.Model;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Reopsitories.EpisodesRepository;

public sealed class EpisodesRepository : IEpisodesRepository
{
    private readonly ApplicationDbContext _context;

    public EpisodesRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Episode>> GetAllEpisodesAsync()
    {
        return await _context.Episodes.ToListAsync();
    }
}