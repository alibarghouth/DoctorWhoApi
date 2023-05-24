using DoctorWho.Web.DTOs.DoctorsDTOs;

namespace DoctorWho.Web.Services.DoctorService;

public interface IDoctorService
{
    Task<List<Doctor>> GetAllDoctors();
    Task<Doctor> UpdateDoctor(Doctor doctorDtOs, int doctorId);
    Task<Doctor> AddDoctor(Doctor doctorDtOs);
}