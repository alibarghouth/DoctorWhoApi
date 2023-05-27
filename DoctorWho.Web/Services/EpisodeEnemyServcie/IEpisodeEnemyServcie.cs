using DoctorWho.Web.DTOs.EpisodeEnemyDTOs;

namespace DoctorWho.Web.Services.EpisodeEnemyServcie
{
    public interface IEpisodeEnemyServcie
    {
        Task<EpisodeEnemy> AddEpisodeEnemy(EpisodeEnemy episodeEnemy);
    }
}
