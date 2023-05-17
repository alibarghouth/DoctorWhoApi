using DoctorWho.Web.DTOs.EpisodeCompanionDTOs;
using DoctorWho.Web.Services.EpisodeCompanionService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodeCompanionsController : ControllerBase
    {
        private readonly IEpisodeCompanionService _episodeCompanionService;

        public EpisodeCompanionsController(IEpisodeCompanionService episodeCompanionService)
        {
            _episodeCompanionService = episodeCompanionService;
        }

        [HttpPost("add_episodeCopanion")]
        public async Task<IActionResult> AddEpisodeCompanionAsync(CreateEpisodeCompanion episodeCompanion)
        {
            return Ok(await _episodeCompanionService.AddEpisodeCompanionAsync(episodeCompanion));
        }
    }
}
