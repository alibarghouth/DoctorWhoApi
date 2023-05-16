using System.Net;
using DoctorWho.Db.Model;
using DoctorWho.Db.Reopsitories.DoctorRepository;
using DoctorWho.Web.DTOs.DoctorsDTOs;
using DoctorWho.Web.Exceptions;
using Mapster;

namespace DoctorWho.Web.Services.DoctorService;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;

    public DoctorService(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<List<GetDoctors>> GetAllDoctorAsync()
    {
        var doctors = await _doctorRepository.GetAllDoctorAsync();
        return doctors.Adapt<List<GetDoctors>>();
    }

    public async Task<DoctorDTOs> UpdateDoctorAsync(DoctorDTOs doctorDtOs, int doctorId)
    {
        if (doctorDtOs is null)
        {
            throw new DoctorWhoExceptions
            {
                Message = "object is null",
                StatusCode = HttpStatusCode.BadRequest
            };
        }

        if (doctorId == 0)
        {
            throw new DoctorWhoExceptions
            {
                Message = "object is exists",
                StatusCode = HttpStatusCode.BadRequest
            };
        }

        var doctor = await FindDoctorById(doctorId);
        if (doctor is null)
        {
            throw new DoctorWhoExceptions
            {
                Message = "object is exists",
                StatusCode = HttpStatusCode.BadRequest
            };
        }

        if (string.IsNullOrEmpty(doctorDtOs.Name))
            doctor.Name = doctorDtOs.Name;
        if (string.IsNullOrEmpty(doctorDtOs.Number))
            doctor.Number = doctorDtOs.Number;
        var doctorUpdated = _doctorRepository.UpdateDoctorAsync(doctor);
        
        return doctorUpdated.Adapt<DoctorDTOs>();
    }

    public async Task<DoctorDTOs> AddDoctorAsync(DoctorDTOs doctorDtOs)
    {
        if (doctorDtOs is null)
        {
            throw new DoctorWhoExceptions
            {
                Message = "object is null",
                StatusCode = HttpStatusCode.BadRequest
            };
        }

        var doctor = doctorDtOs.Adapt<Doctor>();
        await _doctorRepository.AddDoctorAsync(doctor);
        
        return doctorDtOs;
    }

    private async Task<Doctor> FindDoctorById(int doctorId)
    {
        return await _doctorRepository.FindDoctorById(doctorId);
    }
}