namespace DoctorWho.Web.DTOs.DoctorsDTOs;

public record Doctors
{
    public string Name { get; set; }
    public string Number { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime FirstEpisodeDate { get; set; }
    public DateTime LastEpisodeDate { get; set; }
}