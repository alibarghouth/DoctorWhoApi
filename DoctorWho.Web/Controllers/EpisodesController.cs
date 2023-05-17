using DoctorWho.Web.DTOs.EpisodeDTOs;
using DoctorWho.Web.Services.EpisodesServices;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodesController : ControllerBase
    {
        private readonly IEpisodesService _episodesService;

        public EpisodesController(IEpisodesService episodesService)
        {
            _episodesService = episodesService;
        }

        [HttpGet("get_episodes")]
        public async Task<IActionResult> GetAllEpisodesAsync()
        {
            return Ok(await _episodesService.GetAllEpisodesAsync());
        }

        [HttpPost("add_episode")]
        public async Task<IActionResult> AddEpisodeAsync(CreateEpisode createEpisode)
        {
            return Ok(await _episodesService.AddEpisodeAsync(createEpisode));
        }
    }
}