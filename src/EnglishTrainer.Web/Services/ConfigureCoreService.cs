using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Interfaces;
using EnglishTrainer.Infrastructure.Services;
using EnglishTrainer.Web.Interfaces;
using EnglishTrainer.Web.Models;

namespace EnglishTrainer.Web.Services
{
    public static class ConfigureCoreService
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<Verb>), typeof(VerbRepository));
            //services.AddScoped(typeof(IVerbViewModelService), typeof(VerbViewModel));
            return services;
        }
    }
}
