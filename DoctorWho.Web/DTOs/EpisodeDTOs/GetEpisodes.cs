namespace DoctorWho.Web.DTOs.EpisodeDTOs;

public class GetEpisodes
{
    public int SeriesNumber { get; set; }
    public int EpisodeNumber { get; set; }
    public string Episodetype { get; set; }
    public string Title { get; set; }
    public DateTime EpsodeDate { get; set; }
    public int AuthorId { get; set; }
    public int DoctorId { get; set; }
    public string Notes { get; set; }
}