using DoctorWho.Db.Model;
using DoctorWho.Db.Reopsitories.AuthorRepository;
using DoctorWho.Db.Reopsitories.DoctorRepository;
using DoctorWho.Db.Reopsitories.EpisodesRepository;
using DoctorWho.Web.Exceptions;
using Mapster;

namespace DoctorWho.Web.Services.EpisodesServices;

public sealed class EpisodesService : IEpisodesService
{
    private readonly IEpisodesRepository _episodesRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IAuthorRepository _authorRepository;
    public EpisodesService(IEpisodesRepository episodesRepository
        , IDoctorRepository doctorRepository, IAuthorRepository authorRepository)
    {
        _episodesRepository = episodesRepository;
        _doctorRepository = doctorRepository;
        _authorRepository = authorRepository;
    }

    public async Task<List<DTOs.EpisodeDTOs.Episode>> GetAllEpisodes()
    {
        return (await _episodesRepository.GetAllEpisodes())
            .Adapt<List<DTOs.EpisodeDTOs.Episode>>();
    }

    public async Task<DTOs.EpisodeDTOs.Episode> AddEpisode(DTOs.EpisodeDTOs.Episode episode)
    {
        if (!await _authorRepository.IsAuthorExists(episode.AuthorId))
            throw new DoctorWhoNotFound("author not found");
        if (!await _doctorRepository.IsDoctorExists(episode.DoctorId))
            throw new DoctorWhoNotFound("doctor not found");

        var request = episode.Adapt<Episode>();
        return (await _episodesRepository.AddEpisode(request)).Adapt<DTOs.EpisodeDTOs.Episode>();
    }
}