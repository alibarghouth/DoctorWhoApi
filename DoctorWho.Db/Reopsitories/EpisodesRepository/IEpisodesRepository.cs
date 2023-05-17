using DoctorWho.Db.Model;

namespace DoctorWho.Db.Reopsitories.EpisodesRepository;

public interface IEpisodesRepository
{
    Task<List<Episode>> GetAllEpisodesAsync();
}