﻿using DoctorWho.Web.DTOs.EpisodeEnemyDTOs;
using DoctorWho.Web.Services.EpisodeEnemyServcie;
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
        [HttpPost]
        public async Task<IActionResult> AddEpisodeEnemyAsync(EpisodeEnemy createEpisodeEnemy)
        {
            return Ok(await _episodeEnemyServcie.AddEpisodeEnemy(createEpisodeEnemy));
        }
    }
}
