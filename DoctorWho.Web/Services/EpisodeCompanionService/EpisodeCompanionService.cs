using DoctorWho.Db.Model;
using DoctorWho.Db.Reopsitories.EpisodeCompanionRepository;
using DoctorWho.Web.DTOs.EpisodeCompanionDTOs;
using DoctorWho.Web.Exceptions;
using DoctorWho.Web.Services.CompanionService;
using DoctorWho.Web.Services.EpisodesServices;
using Mapster;
using System.Net;

namespace DoctorWho.Web.Services.EpisodeCompanionService
{
    public class EpisodeCompanionService : IEpisodeCompanionService
    {
        private readonly IEpisodeCompanionRepository _episodeCompanionRepository;
        private readonly IEpisodesService _episodesService;
        private readonly ICompanionService _companionService;
        public EpisodeCompanionService(IEpisodeCompanionRepository episodeCompanionRepository, ICompanionService companionService, IEpisodesService episodesService)
        {
            _episodeCompanionRepository = episodeCompanionRepository;
            _companionService = companionService;
            _episodesService = episodesService;
        }

        public async Task<CreateEpisodeCompanion> AddEpisodeCompanionAsync(CreateEpisodeCompanion episodeCompanion)
        {
            if(episodeCompanion is null
                || !await _episodesService.EpisodeIsExists(episodeCompanion.EpisodeId)
                || !await _companionService.CompanionIsExists(episodeCompanion.CompanionId))
            {
                throw new DoctorWhoExceptions
                {
                    Message = "the object is not valid",
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
            var request = episodeCompanion.Adapt<EpisodeCompanion>();
            return (await _episodeCompanionRepository.AddEpisodeCompanionAsync(request)).Adapt<CreateEpisodeCompanion>();
        }
    }
}
