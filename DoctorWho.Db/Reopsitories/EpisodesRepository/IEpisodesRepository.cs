using DoctorWho.Db.Model;

namespace DoctorWho.Db.Reopsitories.EpisodesRepository;

public interface IEpisodesRepository
{
    Task<List<Episode>> GetAllEpisodes();
    Task<Episode> AddEpisode(Episode episode);
    Task<bool> IsEpisodeExists(int episodeId);
}