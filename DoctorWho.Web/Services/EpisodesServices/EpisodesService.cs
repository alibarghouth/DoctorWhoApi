using System.Net;
using DoctorWho.Db.Model;
using DoctorWho.Db.Reopsitories.EpisodesRepository;
using DoctorWho.Web.DTOs.EpisodeDTOs;
using DoctorWho.Web.Exceptions;
using Mapster;

namespace DoctorWho.Web.Services.EpisodesServices;

public class EpisodesService : IEpisodesService
{
    private readonly IEpisodesRepository _episodesRepository;

    public EpisodesService(IEpisodesRepository episodesRepository)
    {
        _episodesRepository = episodesRepository;
    }

    public async Task<List<GetEpisodes>> GetAllEpisodesAsync()
    {
        return (await _episodesRepository.GetAllEpisodesAsync())
            .Adapt<List<GetEpisodes>>();
    }

    public async Task<CreateEpisode> AddEpisodeAsync(CreateEpisode createEpisode)
    {
        if (createEpisode is null)
        {
            throw new DoctorWhoExceptions
            {
                Message = "the object must be not null",
                StatusCode = HttpStatusCode.BadRequest
            };
        }

        var request = createEpisode.Adapt<Episode>();
        return (await _episodesRepository.AddEpisodeAsync(request)).Adapt<CreateEpisode>();
    }
}