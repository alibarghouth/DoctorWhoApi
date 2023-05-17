using DoctorWho.Web.DTOs.EpisodeDTOs;

namespace DoctorWho.Web.Services.EpisodesServices;

public interface IEpisodesService
{
    Task<List<GetEpisodes>> GetAllEpisodesAsync();
    Task<CreateEpisode> AddEpisodeAsync(CreateEpisode createEpisode);
    Task<bool> EpisodeIsExists(int  episodeId);
}