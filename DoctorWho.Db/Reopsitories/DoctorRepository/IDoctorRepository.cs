using DoctorWho.Db.Model;

namespace DoctorWho.Db.Reopsitories.DoctorRepository;

public interface IDoctorRepository
{
    Task<List<Doctor>> GetAllDoctorAsync();
    Task<Doctor> UpdateDoctorAsync(Doctor doctor);
    Task<Doctor> FindDoctorById(int doctorId);
    Task<Doctor> AddDoctorAsync(Doctor doctor);
    Task<bool> DeleteDoctorAsync(Doctor doctor);
}