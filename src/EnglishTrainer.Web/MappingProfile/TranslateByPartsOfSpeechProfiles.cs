using AutoMapper;
using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Models;

namespace EnglishTrainer.Web.MappingProfile
{
    public class TranslateByPartsOfSpeechProfiles : Profile
    {
        public TranslateByPartsOfSpeechProfiles()
        {
            CreateMap<TranslateByPartsOfSpeech, PartsOfSpeechViewModel>();
            CreateMap<PartsOfSpeechViewModel, TranslateByPartsOfSpeech>(); 
        }
    }
}
