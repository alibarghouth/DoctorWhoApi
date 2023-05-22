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

    public async Task<List<Doctors>> GetAllDoctorAsync()
    {
        var doctors = await _doctorRepository.GetAllDoctorAsync();
        return  doctors.Adapt<List<Doctors>>();
    }
}