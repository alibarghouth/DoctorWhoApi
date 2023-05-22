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

    public async Task<List<DoctorRequest>> GetAllDoctors()
    {
        var doctors = await _doctorRepository.GetAllDoctors();
        return doctors.Adapt<List<DoctorRequest>>();
    }

    public async Task<DoctorRequest> UpdateDoctor(DoctorRequest doctorDtOs, int doctorId)
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

        var doctor = await FindDoctorById(doctorId) ?? throw new DoctorWhoExceptions
            {
                Message = "object is exists",
                StatusCode = HttpStatusCode.BadRequest
            };
        if (!string.IsNullOrEmpty(doctorDtOs.Name))
            doctor.Name = doctorDtOs.Name;
        if (!string.IsNullOrEmpty(doctorDtOs.Number))
            doctor.Number = doctorDtOs.Number;
        var doctorUpdated = await _doctorRepository.UpdateDoctor(doctor);
        
        return doctorUpdated.Adapt<DoctorRequest>();
    }

    public async Task<DoctorRequest> AddDoctor(DoctorRequest doctorDtOs)
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
        ;
        
        return (await _doctorRepository.AddDoctor(doctor)).Adapt<DoctorRequest>();
    }

    private async Task<Doctor> FindDoctorById(int doctorId)
    {
        return await _doctorRepository.FindDoctorById(doctorId);
    }
}