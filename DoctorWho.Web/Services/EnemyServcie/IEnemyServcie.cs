namespace DoctorWho.Web.Services.EnemyServcie
{
    public interface IEnemyServcie
    {
        Task<bool> EnemyIsExists(int enemyId);
    }
}
