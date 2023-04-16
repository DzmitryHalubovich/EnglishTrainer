using EnglishTrainer.ApplicationCore.Models;
using EnglishTrainer.Infrastructure.Data;
using EnglishTrainer.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EnglishTrainer.Services.Implementations
{
    public class ApiWordService : IApiWordService
    {
        private readonly EnglishTrainerContext _context;

        public ApiWordService(EnglishTrainerContext context)
        {
            _context = context;
        }

        public async Task<List<WordViewModel>> GetAllAsync()
        {
            var result = await _context.Words.
                Include(x=>x.Examples)
                .Select(p=> new WordViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    TranslateVariants = p.TranslateVariants,
                    Description = p.Description,
                    Examples = p.Examples
                }).ToListAsync();

            return result;
        }
    }
}
