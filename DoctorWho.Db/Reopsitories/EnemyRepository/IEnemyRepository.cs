namespace DoctorWho.Db.Reopsitories.EnemyRepository
{
    public interface IEnemyRepository
    {
        Task<bool> EnemyIsExists(int enemyId);
    }
}
