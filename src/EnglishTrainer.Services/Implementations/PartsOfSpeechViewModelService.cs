using AutoMapper;
using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Interfaces;
using EnglishTrainer.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer.Services
{
    public class PartsOfSpeechViewModelService : IPartsOfSpeechViewModelService
    {
        private readonly IRepository<TranslateByPartsOfSpeech> _partsRepository;
        private readonly IMapper _mapper;

        public PartsOfSpeechViewModelService(IRepository<TranslateByPartsOfSpeech> partsRepository, IMapper mapper)
        {
            _partsRepository=partsRepository;
            _mapper=mapper;
        }

        public async Task<PartsOfSpeechViewModel> GetPartViewModelByIdAsync(int id)
        {
            var entity = await _partsRepository.GetByIdAsync(id);

            var result = _mapper.Map<PartsOfSpeechViewModel>(entity);

            return result;
        }

        public async Task UpdatePartsAsync(PartsOfSpeechViewModel viewModel)
        {
            var existingPart = await _partsRepository.GetByIdAsync(viewModel.Id);

            existingPart.Adjective = viewModel.Adjective;
            existingPart.Preposition = viewModel.Preposition;
            existingPart.Interjection = viewModel.Interjection;
            existingPart.Conjunction = viewModel.Conjunction;
            existingPart.Adverb = viewModel.Adverb;
            existingPart.Noun = viewModel.Noun;
            existingPart.Pronoun = viewModel.Pronoun;
            existingPart.Verb = viewModel.Verb;

            await _partsRepository.UpdateAsync(existingPart);
            
        }
    }
}
