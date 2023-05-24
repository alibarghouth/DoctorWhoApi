using DoctorWho.Db.Model;
using DoctorWho.Db.Reopsitories.DoctorRepository;
using DoctorWho.Web.Exceptions;
using Mapster;

namespace DoctorWho.Web.Services.DoctorService;

public sealed class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;

    public DoctorService(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<List<DTOs.DoctorsDTOs.Doctor>> GetAllDoctors()
    {
        return (await _doctorRepository.GetAllDoctors())
            .Adapt<List<DTOs.DoctorsDTOs.Doctor>>();
    }

    public async Task<DTOs.DoctorsDTOs.Doctor> UpdateDoctor(
        DTOs.DoctorsDTOs.Doctor doctor, int doctorId)
    {
        var oldDoctor = await _doctorRepository.FindDoctorById(doctorId)
            ?? throw new DoctorNotFound("object is not exists");

        var newDoctor = doctor.Adapt(oldDoctor);
        var doctorUpdated = await _doctorRepository.UpdateDoctor(newDoctor);

        return doctorUpdated.Adapt<DTOs.DoctorsDTOs.Doctor>();
    }

    public async Task<DTOs.DoctorsDTOs.Doctor> AddDoctor(DTOs.DoctorsDTOs.Doctor doctorDtOs)
    {
        var doctor = doctorDtOs.Adapt<Doctor>();

        return (await _doctorRepository.AddDoctor(doctor)).Adapt<DTOs.DoctorsDTOs.Doctor>();
    }
    public async Task<bool> DeleteDoctor(int doctorId)
    {
        var doctor = await _doctorRepository.FindDoctorById(doctorId)
         ?? throw new DoctorNotFound("object is not exists");

        return await _doctorRepository.DeleteDoctorAsync(doctor);
    }


}