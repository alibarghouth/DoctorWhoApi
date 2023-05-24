using DoctorWho.Db.Model;

namespace DoctorWho.Db.Reopsitories.DoctorRepository;

public interface IDoctorRepository
{
    Task<List<Doctor>> GetAllDoctors();
    Task<Doctor> UpdateDoctor(Doctor doctor);
    Task<Doctor?> FindDoctorById(int doctorId);
    Task<Doctor> AddDoctor(Doctor doctor);
    Task<bool> DeleteDoctorAsync(Doctor doctor);
}