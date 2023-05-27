using DoctorWho.Db.Context;
using DoctorWho.Db.Model;

namespace DoctorWho.Db.Reopsitories.EpisodeEnemyRepository
{
    public class EpisodeEnemyRepository : IEpisodeEnemyRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EpisodeEnemyRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EpisodeEnemy> AddEpisodeEnemy(EpisodeEnemy episodeEnemy)
        {
            await _dbContext.EpisodeEnemies.AddAsync(episodeEnemy);
            await _dbContext.SaveChangesAsync();
            return episodeEnemy;
        }
    }
}
