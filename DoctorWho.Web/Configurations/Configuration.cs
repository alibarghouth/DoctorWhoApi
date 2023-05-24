﻿using DoctorWho.Db.Context;
using DoctorWho.Db.Reopsitories.DoctorRepository;
using DoctorWho.Db.Reopsitories.EpisodesRepository;
using DoctorWho.Web.DTOs.DoctorsDTOs;
using DoctorWho.Web.Services.DoctorService;
using DoctorWho.Web.Services.EpisodesServices;
using DoctorWho.Web.Validator;
using FluentValidation;
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
            AddCustomDependencies(services);
            AddFluentValidation(services);
        }

        private static void AddDatabase(IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<ApplicationDbContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        private static void AddCustomDependencies(IServiceCollection services)
        {
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IEpisodesRepository, EpisodesRepository>();
            services.AddScoped<IEpisodesService, EpisodesService>();
        }

        private static void AddFluentValidation(IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddScoped<IValidator<Doctor>, DoctorValidation>();
        }
    }
}