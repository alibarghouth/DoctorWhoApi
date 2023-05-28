using DoctorWho.Db.Model;
using DoctorWho.Db.Reopsitories.CompanionRepository;
using DoctorWho.Db.Reopsitories.EpisodeCompanionRepository;
using DoctorWho.Db.Reopsitories.EpisodesRepository;
using DoctorWho.Web.Exceptions;
using Mapster;
using System.Net;

namespace DoctorWho.Web.Services.EpisodeCompanionService
{
    public class EpisodeCompanionService : IEpisodeCompanionService
    {
        private readonly IEpisodeCompanionRepository _episodeCompanionRepository;
        private readonly IEpisodesRepository _episodesRepository;
        private readonly ICompanionRepository _companionRepository;
        public EpisodeCompanionService(IEpisodeCompanionRepository episodeCompanionRepository
            , IEpisodesRepository episodesService, ICompanionRepository companionService)
        {
            _episodeCompanionRepository = episodeCompanionRepository;
            _episodesRepository = episodesService;
            _companionRepository = companionService;
        }

        public async Task<DTOs.EpisodeCompanionDTOs.EpisodeCompanion>
            AddEpisodeCompanionAsync(DTOs.EpisodeCompanionDTOs.EpisodeCompanion episodeCompanion)
        {
            if (!await _episodesRepository.IsEpisodeExists(episodeCompanion.EpisodeId))
            {
                throw new DoctorWhoNotFound("Episode not found");
            }
            if(!await _companionRepository.IsCompanionExists(episodeCompanion.CompanionId))
            {
                throw new DoctorWhoNotFound("Companion not found");
            }
            var request = episodeCompanion.Adapt<EpisodeCompanion>();
            return (await _episodeCompanionRepository.AddEpisodeCompanion(request))
                .Adapt<DTOs.EpisodeCompanionDTOs.EpisodeCompanion>();
        }
    }
}
