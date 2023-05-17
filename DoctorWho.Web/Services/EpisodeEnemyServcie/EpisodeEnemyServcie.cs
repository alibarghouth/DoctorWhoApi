using DoctorWho.Db.Model;
using DoctorWho.Db.Reopsitories.EpisodeEnemyRepository;
using DoctorWho.Web.DTOs.EpisodeEnemyDTOs;
using DoctorWho.Web.Exceptions;
using DoctorWho.Web.Services.EpisodesServices;
using Mapster;
using System.Net;

namespace DoctorWho.Web.Services.EpisodeEnemyServcie
{
    public class EpisodeEnemyServcie : IEpisodeEnemyServcie
    {
        private readonly IEpisodeEnemyRepository _episodeEnemyRepository;
        private readonly IEpisodesService _episodesService;

        public EpisodeEnemyServcie(IEpisodeEnemyRepository episodeEnemyRepository, IEpisodesService episodesService)
        {
            _episodeEnemyRepository = episodeEnemyRepository;
            _episodesService = episodesService;
        }

        public async Task<CreateEpisodeEnemy> AddEpisodeEnemyAsync(CreateEpisodeEnemy episodeEnemy)
        {
            if(episodeEnemy is null)
            {
                throw new DoctorWhoExceptions
                {
                    Message = "the object is null",
                    StatusCode = HttpStatusCode.BadRequest,
                };
            }
            if(!await _episodesService.EpisodeIsExists(episodeEnemy.EpisodeId))
            {
                throw new DoctorWhoExceptions
                {
                    Message = "the episode is not exists",
                    StatusCode = HttpStatusCode.BadRequest,
                };
            }
            var request = episodeEnemy.Adapt<EpisodeEnemy>();
            var episodeEnemies =  (await _episodeEnemyRepository.AddEpisodeEnemyAsync(request)).Adapt<CreateEpisodeEnemy>();
            
            return episodeEnemies;
        }
    }
}
