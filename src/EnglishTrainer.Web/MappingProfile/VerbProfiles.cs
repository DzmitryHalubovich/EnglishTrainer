using AutoMapper;
using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Models;

namespace EnglishTrainer.Web.MappingProfile
{
    public class VerbProfiles : Profile
    {
        public VerbProfiles()
        {
            CreateMap<IrregularVerb, VerbViewModel>();
            CreateMap<VerbIndexViewModel, IrregularVerb>();
        }
    }

}
