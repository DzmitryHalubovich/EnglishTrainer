using EnglishTrainer.ApplicationCore;
using EnglishTrainer.ApplicationCore.Interfaces;
using EnglishTrainer.ApplicationCore.Models;
using EnglishTrainer.Infrastructure.Data;
using EnglishTrainer.Services.Implementations;
using EnglishTrainer.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishTrainer.Services
{
    public static class ConfigureCoreService
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EFTrainerRepository<>));
            services.AddScoped(typeof(IVerbViewModelService), typeof(VerbViewModelService));
            services.AddScoped(typeof(IWordViewModelService),typeof(WordViewModelService));
            services.AddScoped(typeof(IWordViewModelService),typeof(WordViewModelService));
            services.AddScoped(typeof(IApiWordService),typeof(ApiWordService));
            services.AddScoped(typeof(IExampleViewModelService),typeof(ExampleViewModelService));
            services.AddScoped(typeof(ITokenService), typeof(TokenService));
            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddHttpClient();
            services.AddHttpClient("Dictionary", c =>
            {
                c.BaseAddress = new Uri(configuration.GetValue<string>("DictionaryAPI"));
            });


            return services;
        }
    }
}
