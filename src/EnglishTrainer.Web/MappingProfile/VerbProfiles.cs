using AutoMapper;
using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.Web.Models;

namespace EnglishTrainer.Web.MappingProfile
{
    public class VerbProfiles : Profile
    {
        public VerbProfiles()
        {
            CreateMap<Verb, VerbViewModel>();
            CreateMap<VerbIndexViewModel, Verb>();
        }
    }

}
