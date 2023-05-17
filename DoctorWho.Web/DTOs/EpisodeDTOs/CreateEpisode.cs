using System.ComponentModel.DataAnnotations;
using System.Net;
using DoctorWho.Web.Exceptions;

namespace DoctorWho.Web.DTOs.EpisodeDTOs;

public class CreateEpisode
{
    private long _seriesNumber;
    private int _episodeNumber;

    public long SeriesNumber
    {
        get => _seriesNumber;
        set =>
            _seriesNumber = value.ToString().Length >= 10
                ? value
                : throw new DoctorWhoExceptions
                {
                    Message = "the length should more than 10 char",
                    StatusCode = HttpStatusCode.BadRequest
                };
    }

    public int EpisodeNumber
    {
        get => _episodeNumber;
        set =>
            _episodeNumber = value > 0
                ? value
                : throw new DoctorWhoExceptions
                {
                    Message = "the episodeNumber should more than zero",
                    StatusCode = HttpStatusCode.BadRequest
                };
    }

    public string Episodetype { get; set; }
    public string Title { get; set; }
    public DateTime EpsodeDate { get; set; }
    [Required] public int AuthorId { get; set; }
    [Required] public int DoctorId { get; set; }
    public string Notes { get; set; }
}