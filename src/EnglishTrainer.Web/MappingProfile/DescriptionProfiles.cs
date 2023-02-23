using AutoMapper;
using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.Web.Models;

namespace EnglishTrainer.Web.MappingProfile
{
    public class DescriptionProfiles : Profile
    {
        public DescriptionProfiles()
        {
            CreateMap<Description, DescriptionViewModel>();
            CreateMap<DescriptionViewModel, Description>();
        }
    }
}
