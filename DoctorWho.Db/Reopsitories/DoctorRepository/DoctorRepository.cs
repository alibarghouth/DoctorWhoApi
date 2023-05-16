using DoctorWho.Db.Context;
using DoctorWho.Db.Model;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Reopsitories.DoctorRepository;

public class DoctorRepository : IDoctorRepository
{
    private readonly ApplicationDbContext _dbContext;

    public DoctorRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Doctor>> GetAllDoctorAsync()
    {
        return await _dbContext.Doctors.ToListAsync();
    }

    public Doctor UpdateDoctorAsync(Doctor doctor)
    { 
        _dbContext.Doctors.Update(doctor);
        _dbContext.SaveChanges();
        return doctor;
    }

    public async Task<Doctor> FindDoctorById(int doctorId)
    {
        return await _dbContext.Doctors.FindAsync(doctorId);
    }

    public async Task<Doctor> AddDoctorAsync(Doctor doctor)
    {
        await _dbContext.Doctors.AddAsync(doctor);
        await _dbContext.SaveChangesAsync();
        return doctor;
    }
}