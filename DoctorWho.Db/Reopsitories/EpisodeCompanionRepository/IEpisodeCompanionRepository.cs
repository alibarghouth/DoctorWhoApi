using DoctorWho.Db.Model;

namespace DoctorWho.Db.Reopsitories.EpisodeCompanionRepository
{
    public interface IEpisodeCompanionRepository
    {
        Task<EpisodeCompanion> AddEpisodeCompanion(EpisodeCompanion episodeCompanion);
    }
}
