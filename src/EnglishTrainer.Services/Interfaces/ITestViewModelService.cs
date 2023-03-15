using EnglishTrainer.ApplicationCore.Interfaces;
using EnglishTrainer.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer.Services.Interfaces
{
    public interface ITestViewModelService
    {
        Task<VerbViewModel> GetVerbViewModelByIdAsync(int id);

    }
}
