using AutoMapper;
using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Interfaces;
using EnglishTrainer.ApplicationCore.QueryOptions;
using EnglishTrainer.Web.Interfaces;
using EnglishTrainer.Web.Models;

namespace EnglishTrainer.Web.Services
{
    public class DescriptionViewModelService : IDescriptionViewModelService
    {
        private readonly IRepository<Description> _descriptionRepository;
        private readonly IMapper _mapper;

        public DescriptionViewModelService(IRepository<Description> descriptionRepository, IMapper mapper)
        {
            _descriptionRepository=descriptionRepository;
            _mapper=mapper;
        }

        public async Task<DescriptionViewModel> GetDescriptionViewModelByIdAsync(int id)
        {


            var foundDescription = await _descriptionRepository.GetByIdAsync(id);

            var result = _mapper.Map<DescriptionViewModel>(foundDescription);

            return result;
        }
    }
}
