using DoctorWho.Web.DTOs.EpisodeCompanionDTOs;

namespace DoctorWho.Web.Services.EpisodeCompanionService
{
    public interface IEpisodeCompanionService
    {
        Task<CreateEpisodeCompanion> AddEpisodeCompanionAsync(CreateEpisodeCompanion episodeCompanion);
    }
}
