using DoctorWho.Web.DTOs.DoctorsDTOs;

namespace DoctorWho.Web.Services.DoctorService;

public interface IDoctorService
{
    Task<List<DoctorRequest>> GetAllDoctors();
    Task<DoctorRequest> UpdateDoctor(DoctorRequest doctorDtOs, int doctorId);
    Task<DoctorRequest> AddDoctor(DoctorRequest doctorDtOs);
}