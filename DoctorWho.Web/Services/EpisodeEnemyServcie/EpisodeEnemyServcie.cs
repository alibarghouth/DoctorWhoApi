using DoctorWho.Db.Model;
using DoctorWho.Db.Reopsitories.EpisodeEnemyRepository;
using DoctorWho.Web.DTOs.EpisodeEnemyDTOs;
using DoctorWho.Web.Exceptions;
using DoctorWho.Web.Services.EnemyServcie;
using DoctorWho.Web.Services.EpisodesServices;
using Mapster;
using System.Net;

namespace DoctorWho.Web.Services.EpisodeEnemyServcie
{
    public class EpisodeEnemyServcie : IEpisodeEnemyServcie
    {
        private readonly IEpisodeEnemyRepository _episodeEnemyRepository;
        private readonly IEpisodesService _episodesService;
        private readonly IEnemyServcie _enemyServcie;

        public EpisodeEnemyServcie(IEpisodeEnemyRepository episodeEnemyRepository, IEpisodesService episodesService, IEnemyServcie enemyServcie)
        {
            _episodeEnemyRepository = episodeEnemyRepository;
            _episodesService = episodesService;
            _enemyServcie = enemyServcie;
        }

        public async Task<CreateEpisodeEnemy> AddEpisodeEnemyAsync(CreateEpisodeEnemy episodeEnemy)
        {
            if(episodeEnemy is null 
                || !await _episodesService.EpisodeIsExists(episodeEnemy.EpisodeId) 
                || !await _enemyServcie.EnemyIsExists(episodeEnemy.EnemyId))
            {
                throw new DoctorWhoExceptions
                {
                    Message = "the object is not valid",
                    StatusCode = HttpStatusCode.BadRequest,
                };
            }
            
            var request = episodeEnemy.Adapt<EpisodeEnemy>();
            var episodeEnemies =  (await _episodeEnemyRepository.AddEpisodeEnemyAsync(request)).Adapt<CreateEpisodeEnemy>();
            
            return episodeEnemies;
        }
    }
}
