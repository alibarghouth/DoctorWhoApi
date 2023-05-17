using DoctorWho.Db.Context;
using DoctorWho.Db.Model;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Reopsitories.EpisodesRepository;

public class EpisodesRepository : IEpisodesRepository
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

    public async Task<Episode> AddEpisodeAsync(Episode episode)
    {
        await _context.Episodes.AddAsync(episode);
        await _context.SaveChangesAsync();

        return episode;
    }

    public async Task<bool> EpisodeIsExists(int episodeId)
    {
        return await _context.Episodes.AnyAsync(x => x.Id == episodeId);
    }
}