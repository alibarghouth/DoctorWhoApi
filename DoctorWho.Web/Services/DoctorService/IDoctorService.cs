using DoctorWho.Web.DTOs.DoctorsDTOs;

namespace DoctorWho.Web.Services.DoctorService;

public interface IDoctorService
{
    Task<List<Doctor>> GetAllDoctors();
}