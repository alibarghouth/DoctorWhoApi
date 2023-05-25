using DoctorWho.Db.Context;
using DoctorWho.Db.Model;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Reopsitories.DoctorRepository;

public sealed class DoctorRepository : IDoctorRepository
{
    private readonly ApplicationDbContext _dbContext;

    public DoctorRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Doctor>> GetAllDoctors()
    {
        return await _dbContext.Doctors
            .AsNoTracking().ToListAsync();
    }

    public async Task<Doctor> UpdateDoctor(Doctor doctor)
    {
        _dbContext.Doctors.Update(doctor);
        await _dbContext.SaveChangesAsync();
        return doctor;
    }

    public async Task<Doctor?> FindDoctorById(int doctorId)
    {
        return await _dbContext.Doctors.FindAsync(doctorId);
    }

    public async Task<Doctor> AddDoctor(Doctor doctor)
    {
        await _dbContext.Doctors.AddAsync(doctor);
        await _dbContext.SaveChangesAsync();
        return doctor;
    }
    public async Task<bool> DeleteDoctor(Doctor doctor)
    {
        _dbContext.Doctors.Remove(doctor);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DoctorIsExists(int doctorId)
    {
        return await _dbContext.Doctors
            .AsNoTracking()
            .AnyAsync(x => x.Id == doctorId);
    }
}