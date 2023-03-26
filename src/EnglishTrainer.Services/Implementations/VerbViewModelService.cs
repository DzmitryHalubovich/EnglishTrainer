using AutoMapper;
using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Interfaces;
using EnglishTrainer.ApplicationCore.Models;
using EnglishTrainer.Infrastructure.SortOptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EnglishTrainer.Services
{
    public class VerbViewModelService : IVerbViewModelService
    {
        private readonly IRepository<IrregularVerb> _verbRepository;
        private readonly ILogger<VerbViewModelService> _logger;
        private readonly IMapper _mapper;

        public VerbViewModelService(IRepository<IrregularVerb> verbRepository, IMapper mapper, ILogger<VerbViewModelService> logger)
        {
            _verbRepository = verbRepository;
            _mapper = mapper;
            _logger=logger;
        }
        public async Task<IEnumerable<VerbViewModel>> GetAllVerbsAsync(SortFilterPageOptions options)
        {
            var getAllVerbs = await _verbRepository.GetAllAsync(options, isTracking:true); //look in database all our enteties

            _logger.LogInformation("Запрос на получение таблицы неправильных глаголов.");

            var allVerbsDto = _mapper.Map<IEnumerable<VerbViewModel>>(getAllVerbs);

            return allVerbsDto;
        }

        public async Task<VerbViewModel> GetVerbViewModelByIdAsync(int id)
        {
            var entity = await _verbRepository.GetFirstOrDefaultAsync(x=>x.Id==id);

            var result = _mapper.Map<VerbViewModel>(entity);

            return result;
        }

        public async Task<int> TotalVerbsCount()
        {
            return await _verbRepository.TotalCount();
        }
    }
}
