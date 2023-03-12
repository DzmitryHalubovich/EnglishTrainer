using AutoMapper;
using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Models;

namespace EnglishTrainer.Web.MappingProfile
{
    public class WordProfile : Profile
    {
        public WordProfile()
        {
            CreateMap<Word, WordViewModel>();
            CreateMap<WordViewModel, Word>();

            CreateMap<Word, WordShortViewModel>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(entity => entity.Id))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(entity => entity.Name));

        }
    }
}
