namespace DoctorWho.Db.Reopsitories.EnemyRepository
{
    public interface IEnemyRepository
    {
        Task<bool> IsEnemyExists(int enemyId);
    }
}
