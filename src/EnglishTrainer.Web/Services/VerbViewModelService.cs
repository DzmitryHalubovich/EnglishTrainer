using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Interfaces;
using EnglishTrainer.Web.Interfaces;
using EnglishTrainer.Web.Models;
using EnglishTrainer.Web.Services.QueryOptions;

namespace EnglishTrainer.Web.Services
{
    public class VerbViewModelService : IVerbViewModelService
    {
        private readonly IRepository<Verb> _verbRepository;

        public VerbViewModelService(IRepository<Verb> verbRepository)
        {
            _verbRepository = verbRepository;
        }
        public async Task<IList<VerbViewModel>> GetAllVerbsAsync(int page, int pageSize)
        {
            var entities = await _verbRepository.GetAllAsync(); //look in database all our enteties
            
            var verbs = entities.Skip(page*pageSize).Take(pageSize).Select(item => new VerbViewModel()
            {
                Id = item.Id,
                Infinitive= item.Infinitive,
                PastSimple= item.PastSimple,
                PastParticiple= item.PastParticiple,
                TranslateRu = item.TranslateRu
            }).ToList();

            return verbs;
        }
    }
}
