using DoctorWho.Db.Model;

namespace DoctorWho.Db.Reopsitories.EpisodeEnemyRepository
{
    public interface IEpisodeEnemyRepository
    {
        Task<EpisodeEnemy> AddEpisodeEnemy(EpisodeEnemy episodeEnemy);
    }
}
