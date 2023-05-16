using DoctorWho.Db.Model;

namespace DoctorWho.Db.Reopsitories.DoctorRepository;

public interface IDoctorRepository
{
    Task<List<Doctor>> GetAllDoctorAsync();
}