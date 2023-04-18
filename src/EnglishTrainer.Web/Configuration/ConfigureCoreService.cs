using EnglishTrainer.ApplicationCore;
using EnglishTrainer.ApplicationCore.Interfaces;
using EnglishTrainer.ApplicationCore.Models;
using EnglishTrainer.Infrastructure.Data;
using EnglishTrainer.Services.Implementations;
using EnglishTrainer.Services.Interfaces;

namespace EnglishTrainer.Services
{
    public static class ConfigureCoreService
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EFTrainerRepository<>));
            services.AddScoped(typeof(IVerbViewModelService), typeof(VerbViewModelService));
            services.AddScoped(typeof(IWordViewModelService),typeof(WordViewModelService));
            services.AddScoped(typeof(IWordViewModelService),typeof(WordViewModelService));
            services.AddScoped(typeof(IApiWordService),typeof(ApiWordService));
            services.AddScoped(typeof(IExampleViewModelService),typeof(ExampleViewModelService));
            services.AddScoped(typeof(ITokenService), typeof(TokenService));
            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddScoped(typeof(IPictureService), typeof(PictureService));

            return services;
        }
    }
}
