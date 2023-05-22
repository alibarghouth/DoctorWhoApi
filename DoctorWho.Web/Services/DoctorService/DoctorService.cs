using DoctorWho.Db.Reopsitories.DoctorRepository;
using DoctorWho.Web.DTOs.DoctorsDTOs;
using Mapster;

namespace DoctorWho.Web.Services.DoctorService;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;

    public DoctorService(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<List<Doctor>> GetAllDoctors()
    {
        var doctors = await _doctorRepository.GetAllDoctors();
        return  doctors.Adapt<List<Doctor>>();
    }
}