using AutoMapper;
using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Models;

namespace EnglishTrainer.Web.MappingProfile
{
    public class VerbProfiles : AutoMapper.Profile
    {
        public VerbProfiles()
        {
            CreateMap<IrregularVerb, VerbViewModel>();
            CreateMap<VerbViewModel, IrregularVerb>();
        }
    }

}
