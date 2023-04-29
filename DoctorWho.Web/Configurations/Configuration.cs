using DoctorWho.Db;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Web.Configurations
{
    public static class Configuration
    {
        public static void AddDoctorWhoConfiguration(this IServiceCollection services, ConfigurationManager configuration)
        {
            AddDatabase(services, configuration);
            AddFluentValidation(services);
            AddMaapperConfiguration(services);
        }
        private static void AddDatabase(IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<ApplicationDBContext>(option =>
                   option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
        private static void AddFluentValidation(IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            //builder.Services.AddScoped<IValidator<AddClass>, AddClassValidator>();
        }
        public static void AddMaapperConfiguration(IServiceCollection services)
        {
        }
    }
}
