using DoctorWho.Db.Context;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Reopsitories.EnemyRepository
{
    public class EnemyRepository : IEnemyRepository
    {
        private readonly ApplicationDbContext _context;

        public EnemyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> EnemyIsExists(int enemyId)
        {
            return await _context.Enemies
                .AsNoTracking()
                .AnyAsync(x => x.Id == enemyId);
        }
    }
}
