using DoctorWho.Db.Context;
using DoctorWho.Db.Model;

namespace DoctorWho.Db.Reopsitories.EpisodeCompanionRepository
{
    public class EpisodeCompanionRepository : IEpisodeCompanionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EpisodeCompanionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EpisodeCompanion> AddEpisodeCompanionAsync(EpisodeCompanion episodeCompanion)
        {
            await _dbContext.EpisodeCompanions.AddAsync(episodeCompanion);
            await _dbContext.SaveChangesAsync();    
            return episodeCompanion;
        }
    }
}
