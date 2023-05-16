using DoctorWho.Db.Model;

namespace DoctorWho.Web.Services.DoctorService;

public interface IDoctorService
{
    Task<List<Doctor>> GetAllDoctorAsync();
}