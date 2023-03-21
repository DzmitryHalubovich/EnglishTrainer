using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Interfaces;
using EnglishTrainer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer.Services.Implementations
{
    public class PictureService : IPictureService
    {
        private readonly IRepository<Picture> _pictureRepository;

        public PictureService(IRepository<Picture> pictureRepository)
        {
            _pictureRepository=pictureRepository;
        }

        public async Task CreatePictureAsync(Picture viewModel)
        {
            await _pictureRepository.CreateAsync(viewModel);
        }


    }
}
