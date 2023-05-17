using DoctorWho.Db.Reopsitories.EnemyRepository;

namespace DoctorWho.Web.Services.EnemyServcie
{
    public class EnemyServcie : IEnemyServcie
    {
        private readonly IEnemyRepository _enemyRepository;

        public EnemyServcie(IEnemyRepository enemyRepository)
        {
            _enemyRepository = enemyRepository;
        }

        public async Task<bool> EnemyIsExists(int enemyId)
        {
            return await _enemyRepository.EnemyIsExists(enemyId);
        }
    }
}
