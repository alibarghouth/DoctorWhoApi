using DoctorWho.Db.Model;
using DoctorWho.Db.Reopsitories.DoctorRepository;
using DoctorWho.Web.DTOs.DoctorsDTOs;
using DoctorWho.Web.Exceptions;
using Mapster;
using System.Net;

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

        var doctor = await _doctorRepository.FindDoctorById(doctorId) ?? throw new DoctorWhoExceptions
        {
            Message = "object not found",
            StatusCode = HttpStatusCode.BadRequest
        };

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
    public async Task<bool> DeleteDoctorAsync(int doctorId)
    {
        if (doctorId == 0)
        {
            throw new DoctorWhoExceptions
            {
                Message = "object is exists",
                StatusCode = HttpStatusCode.BadRequest
            };
        }
        var doctor = await _doctorRepository.FindDoctorById(doctorId) ?? throw new DoctorWhoExceptions
        {
            Message = "object not found",
            StatusCode = HttpStatusCode.BadRequest
        };

        return await _doctorRepository.DeleteDoctorAsync(doctor);
    }


}