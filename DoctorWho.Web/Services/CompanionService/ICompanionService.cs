namespace DoctorWho.Web.Services.CompanionService
{
    public interface ICompanionService
    {
        Task<bool> CompanionIsExists(int companionId);
    }
}
