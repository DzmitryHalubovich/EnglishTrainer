using AutoMapper;
using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Models;

namespace EnglishTrainer.Web.MappingProfile
{
    public class ExampleProfiles : Profile
    {
        public ExampleProfiles()
        {
            CreateMap<Example, ExampleViewModel>();
            CreateMap<ExampleViewModel, Example>();
        }
    }
}
