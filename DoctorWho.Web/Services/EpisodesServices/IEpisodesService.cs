﻿using DoctorWho.Web.DTOs.EpisodeDTOs;

namespace DoctorWho.Web.Services.EpisodesServices;

public interface IEpisodesService
{
    Task<List<Episode>> GetAllEpisodes();
    Task<Episode> AddEpisode(Episode episode);
}