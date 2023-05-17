using DoctorWho.Db.Model;

namespace DoctorWho.Db.Reopsitories.EpisodesRepository;

public interface IEpisodesRepository
{
    Task<List<Episode>> GetAllEpisodesAsync();
    Task<Episode> AddEpisodeAsync(Episode episode);
    Task<bool> EpisodeIsExists(int episodeId);
}