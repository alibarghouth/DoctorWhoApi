namespace DoctorWho.Db.Reopsitories.CompanionRepository
{
    public interface ICompanionRepository
    {
        Task<bool> IsCompanionExists(int companionId);
    }
}
