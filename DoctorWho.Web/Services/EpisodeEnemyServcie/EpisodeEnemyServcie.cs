using DoctorWho.Db.Model;
using DoctorWho.Db.Reopsitories.EnemyRepository;
using DoctorWho.Db.Reopsitories.EpisodeEnemyRepository;
using DoctorWho.Db.Reopsitories.EpisodesRepository;
using DoctorWho.Web.Exceptions;
using Mapster;

namespace DoctorWho.Web.Services.EpisodeEnemyServcie;

public sealed class EpisodeEnemyServcie : IEpisodeEnemyServcie
{
    private readonly IEpisodeEnemyRepository _episodeEnemyRepository;
    private readonly IEpisodesRepository _episodesRepository;
    private readonly IEnemyRepository _enemyRepository;
    public EpisodeEnemyServcie(IEpisodeEnemyRepository episodeEnemyRepository
        , IEpisodesRepository episodesRepository, IEnemyRepository enemyRepository)
    {
        _episodeEnemyRepository = episodeEnemyRepository;
        _episodesRepository = episodesRepository;
        _enemyRepository = enemyRepository;
    }

    public async Task<DTOs.EpisodeEnemyDTOs.EpisodeEnemy> AddEpisodeEnemy(DTOs.EpisodeEnemyDTOs.EpisodeEnemy episodeEnemy)
    {
        if (!await _episodesRepository.IsEpisodeExists(episodeEnemy.EpisodeId))
        {
            throw new DoctorWhoNotFound("episode Not Found");
        }
        if (!await _enemyRepository.IsEnemyExists(episodeEnemy.EnemyId))
        {
            throw new DoctorWhoNotFound("enemy Not Found");
        }
        var request = episodeEnemy.Adapt<EpisodeEnemy>();
        var episodeEnemies = (await _episodeEnemyRepository.AddEpisodeEnemy(request)).Adapt<DTOs.EpisodeEnemyDTOs.EpisodeEnemy>();

        return episodeEnemies;
    }
}