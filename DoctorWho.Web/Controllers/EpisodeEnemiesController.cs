using DoctorWho.Web.DTOs.EpisodeEnemyDTOs;
using DoctorWho.Web.Services.EpisodeEnemyServcie;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodeEnemiesController : ControllerBase
    {
        private readonly IEpisodeEnemyServcie _episodeEnemyServcie;

        public EpisodeEnemiesController(IEpisodeEnemyServcie episodeEnemyServcie)
        {
            _episodeEnemyServcie = episodeEnemyServcie;
        }
        public async Task<IActionResult> AddEpisodeEnemyAsync(CreateEpisodeEnemy createEpisodeEnemy)
        {
           return Ok(await _episodeEnemyServcie.AddEpisodeEnemyAsync(createEpisodeEnemy));
        }
    }
}
