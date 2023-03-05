using AutoMapper;
using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Interfaces;
using EnglishTrainer.ApplicationCore.Models;
using EnglishTrainer.ApplicationCore.QueryOptions;

namespace EnglishTrainer.Services
{
    public class VerbViewModelService : IVerbViewModelService
    {
        private readonly IRepository<IrregularVerb> _verbRepository;
        private readonly IMapper _mapper;

        public VerbViewModelService(IRepository<IrregularVerb> verbRepository, IMapper mapper)
        {
            _verbRepository = verbRepository;
            _mapper = mapper;
        }
        public async Task<IList<VerbViewModel>> GetAllVerbsAsync(VerbQueryOptions verbQueryOptions)
        {
            var options = new QueryEntityOptions<IrregularVerb>()
                .SetCurentPageAndPageSize(verbQueryOptions.PageOptions);

            var entities = await _verbRepository.GetAllAsync(options); //look in database all our enteties
            //var verbs = _mapper.Map<List<VerbViewModel>>(entities);
            var verbs = entities.Select(item => new VerbViewModel()
            {
                VerbId = item.Id,
                Infinitive= item.Infinitive,
                PastSimple= item.PastSimple,
                PastParticiple= item.PastParticiple,
                ShortTranslate = item.ShortTranslate,
            }).ToList();

            return verbs;
        }

        public async Task<VerbViewModel> GetVerbViewModelByIdAsync(int id)
        {
            var entity = await _verbRepository.GetByIdAsync(id);

            var result = _mapper.Map<VerbViewModel>(entity);

            return result;
        }
    }
}
