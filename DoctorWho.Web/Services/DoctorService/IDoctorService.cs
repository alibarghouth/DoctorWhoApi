using DoctorWho.Web.DTOs.DoctorsDTOs;

namespace DoctorWho.Web.Services.DoctorService;

public interface IDoctorService
{
    Task<List<GetDoctors>> GetAllDoctorAsync();
    Task<DoctorDTOs> UpdateDoctorAsync(DoctorDTOs doctorDtOs, int doctorId);
    Task<DoctorDTOs> AddDoctorAsync(DoctorDTOs doctorDtOs);
    Task<bool> DeleteDoctorAsync(int doctorId);
}