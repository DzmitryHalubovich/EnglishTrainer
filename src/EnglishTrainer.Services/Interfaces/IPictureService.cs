using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer.Services.Interfaces
{
    public interface IPictureService
    {
        Task CreatePictureAsync(Picture viewModel);
    }
}
