using AutoMapper;
using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.Web.Models;

namespace EnglishTrainer.Web.MappingProfile
{
    public class WordProfile : Profile
    {
        public WordProfile()
        {
            CreateMap<Word, WordViewModel>();
            CreateMap<WordViewModel, Word>();
        }
    }
}
