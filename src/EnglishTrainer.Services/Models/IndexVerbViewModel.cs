using EnglishTrainer.ApplicationCore.Models;
using EnglishTrainer.Infrastructure.SortOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer.Services.Models
{
    public class IndexVerbViewModel
    {

        public IndexVerbViewModel(SortFilterPageOptions sortFilterPageData, IEnumerable<VerbViewModel> verbsList)
        {
            SortFilterPageData = sortFilterPageData;
            VerbsList = verbsList;
        }

        public SortFilterPageOptions SortFilterPageData { get; private set; }

        public IEnumerable<VerbViewModel> VerbsList { get; private set; }
    }
}
