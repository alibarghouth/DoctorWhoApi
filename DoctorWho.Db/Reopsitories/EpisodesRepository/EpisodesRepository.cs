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

    public async Task<List<Episode>> GetAllEpisodes()
    {
        return await _context.Episodes
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Episode> AddEpisode(Episode episode)
    {
        await _context.Episodes.AddAsync(episode);
        await _context.SaveChangesAsync();

        return episode;
    }

    public async Task<bool> IsEpisodeExists(int episodeId)
    {
       return await _context.Episodes
            .AsNoTracking()
            .AnyAsync(x =>x .Id == episodeId);  
    }
}