using Microsoft.Build.Framework;

namespace DoctorWho.Web.DTOs.DoctorsDTOs;

public class DoctorRequest
{
    private DateTime? firstEpisodeDate;
    private DateTime? lastEpisodeDate;

    [Required] public string? Name { get; set; }
    [Required] public string? Number { get; set; }
    public DateTime BirthDate { get; set; }

    public DateTime? FirstEpisodeDate
    {
        get => firstEpisodeDate;
        set => firstEpisodeDate = value;
    }
    public DateTime? LastEpisodeDate
    {
        get => lastEpisodeDate;
        set
        {
            lastEpisodeDate = value;
            if (string.IsNullOrEmpty(firstEpisodeDate.ToString())
                || firstEpisodeDate > lastEpisodeDate)
            {
                firstEpisodeDate = null;
                lastEpisodeDate = null;
            }
        }
    }
}