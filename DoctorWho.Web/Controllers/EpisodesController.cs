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

        [HttpGet]
        public async Task<IActionResult> GetAllEpisodesAsync()
        {
            return Ok(await _episodesService.GetAllEpisodes());
        }

        [HttpPost]
        public async Task<IActionResult> AddEpisode(Episode episode)
        {
            return Ok(await _episodesService.AddEpisode(episode));
        }
    }
}