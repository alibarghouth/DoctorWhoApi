namespace DoctorWho.Db.Reopsitories.CompanionRepository
{
    public interface ICompanionRepository
    {
        Task<bool> CompanionIsExists(int companionId);
    }
}
