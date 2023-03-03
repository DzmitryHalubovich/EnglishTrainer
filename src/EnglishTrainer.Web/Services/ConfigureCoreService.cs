using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Interfaces;
using EnglishTrainer.Infrastructure.Data;
using EnglishTrainer.Web.Interfaces;
using EnglishTrainer.Web.Models;

namespace EnglishTrainer.Web.Services
{
    public static class ConfigureCoreService
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EFTrainerRepository<>));
            services.AddScoped(typeof(IVerbViewModelService), typeof(VerbViewModelService));
            return services;
        }
    }
}
