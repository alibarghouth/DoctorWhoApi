using DoctorWho.Db.Context;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Reopsitories.CompanionRepository
{
    public class CompanionRepository : ICompanionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CompanionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> IsCompanionExists(int companionId)
        {
            return await _dbContext.Companions.AnyAsync(x => x.Id == companionId);
        }
    }
}
