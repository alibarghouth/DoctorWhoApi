using DoctorWho.Db.Context;
using DoctorWho.Db.Reopsitories.DoctorRepository;
using DoctorWho.Web.Services.DoctorService;
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
            AddCustomDependencies (services);
            AddFluentValidation(services);
        }

        private static void AddDatabase(IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<ApplicationDbContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        private static void AddCustomDependencies (IServiceCollection services)
        {
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IDoctorService, DoctorService>();
        }

        private static void AddFluentValidation(IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
        }
    }
}