using DoctorWho.Db.Model;
using DoctorWho.Db.Reopsitories.DoctorRepository;

namespace DoctorWho.Web.Services.DoctorService;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;

    public DoctorService(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<List<Doctor>> GetAllDoctorAsync()
    {
        return await _doctorRepository.GetAllDoctorAsync();
    }
}