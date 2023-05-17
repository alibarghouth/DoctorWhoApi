using DoctorWho.Db.Context;
using DoctorWho.Db.Reopsitories.AuthorRepository;
using DoctorWho.Db.Reopsitories.CompanionRepository;
using DoctorWho.Db.Reopsitories.DoctorRepository;
using DoctorWho.Db.Reopsitories.EnemyRepository;
using DoctorWho.Db.Reopsitories.EpisodeCompanionRepository;
using DoctorWho.Db.Reopsitories.EpisodeEnemyRepository;
using DoctorWho.Db.Reopsitories.EpisodesRepository;
using DoctorWho.Web.Services.AuthorService;
using DoctorWho.Web.Services.CompanionService;
using DoctorWho.Web.Services.DoctorService;
using DoctorWho.Web.Services.EnemyServcie;
using DoctorWho.Web.Services.EpisodeCompanionService;
using DoctorWho.Web.Services.EpisodeEnemyServcie;
using DoctorWho.Web.Services.EpisodesServices;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Web.Configurations
{
    public static class Configuration
    {
        public static void AddDoctorWhoConfiguration(this IServiceCollection services,
            ConfigurationManager configuration)
        {
            AddDatabase(services, configuration);
            AddDependencyInjections(services);
            AddFluentValidation(services);
        }

        private static void AddDatabase(IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<ApplicationDbContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        private static void AddDependencyInjections(IServiceCollection services)
        {
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IEpisodesService, EpisodesService>();
            services.AddScoped<IEpisodesRepository, EpisodesRepository>();
            services.AddScoped<ICompanionRepository, CompanionRepository>();
            services.AddScoped<ICompanionService, CompanionService>();
            services.AddScoped<IEpisodeCompanionRepository, EpisodeCompanionRepository>();
            services.AddScoped<IEpisodeCompanionService, EpisodeCompanionService>();
            services.AddScoped<IEpisodeEnemyRepository, EpisodeEnemyRepository>();
            services.AddScoped<IEpisodeEnemyServcie, EpisodeEnemyServcie>();
            services.AddScoped<IEnemyRepository, EnemyRepository>();
            services.AddScoped<IEnemyServcie, EnemyServcie>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
        }

        private static void AddFluentValidation(IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
        }
    }
}