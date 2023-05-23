using System;
using System.Net;
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
        if (doctorId == 0)
        {
            throw new DoctorWhoExceptions
            {
                Message = "object is not exists",
                StatusCode = HttpStatusCode.NotFound
            };
        }

        var oldDoctor = await _doctorRepository.FindDoctorById(doctorId) 
            ?? throw new DoctorWhoExceptions
            {
                Message = "object is not exists",
                StatusCode = HttpStatusCode.NotFound
            };

        var newDoctor = doctor.Adapt(oldDoctor);
        var doctorUpdated = await _doctorRepository.UpdateDoctor(newDoctor);

        return doctorUpdated.Adapt<DTOs.DoctorsDTOs.Doctor>();
    }

    public async Task<DTOs.DoctorsDTOs.Doctor> AddDoctor(DTOs.DoctorsDTOs.Doctor doctorDtOs)
    {
        var doctor = doctorDtOs.Adapt<Doctor>();
        
        return (await _doctorRepository.AddDoctor(doctor)).Adapt<DTOs.DoctorsDTOs.Doctor>();
    }
}