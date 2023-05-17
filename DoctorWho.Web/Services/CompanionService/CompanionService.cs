using DoctorWho.Db.Reopsitories.CompanionRepository;

namespace DoctorWho.Web.Services.CompanionService
{
    public class CompanionService : ICompanionService
    {
        private readonly ICompanionRepository _companionRepository;

        public CompanionService(ICompanionRepository companionRepository)
        {
            _companionRepository = companionRepository;
        }

        public async Task<bool> CompanionIsExists(int companionId)
        {
            return await _companionRepository.CompanionIsExists(companionId);
        }
    }
}
