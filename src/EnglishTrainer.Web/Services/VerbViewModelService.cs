﻿using AutoMapper;
using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Interfaces;
using EnglishTrainer.ApplicationCore.QueryOptions;
using EnglishTrainer.Web.Interfaces;
using EnglishTrainer.Web.Models;
using EnglishTrainer.Web.Services.QueryOptions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EnglishTrainer.Web.Services
{
    public class VerbViewModelService : IVerbViewModelService
    {
        private readonly IRepository<Verb> _verbRepository;
        private readonly IMapper _mapper;

        public VerbViewModelService(IRepository<Verb> verbRepository, IMapper mapper)
        {
            _verbRepository = verbRepository;
            _mapper = mapper;
        }
        public async Task<IList<VerbViewModel>> GetAllVerbsAsync(VerbQueryOptions verbQueryOptions)
        {
            var options = new QueryEntityOptions<Verb>()
                .SetCurentPageAndPageSize(verbQueryOptions.PageOptions);

            var entities = await _verbRepository.GetAllAsync(options); //look in database all our enteties
            //var verbs = _mapper.Map<List<VerbViewModel>>(entities);
            var verbs = entities.Select(item => new VerbViewModel()
            {
                Id = item.VerbId,
                Infinitive= item.Infinitive,
                PastSimple= item.PastSimple,
                PastParticiple= item.PastParticiple,
                ShortTranslate = item.ShortTranslate
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
