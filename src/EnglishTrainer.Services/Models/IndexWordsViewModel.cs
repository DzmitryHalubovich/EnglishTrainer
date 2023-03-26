using EnglishTrainer.ApplicationCore.Models;
using EnglishTrainer.Infrastructure.SortOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer.Services.Models
{
    public class IndexWordsViewModel
    {
        public IndexWordsViewModel(SortFilterPageOptions sortFilterPageData, IEnumerable<WordViewModel> wordsList)
        {
            SortFilterPageData = sortFilterPageData;
            WordsList = wordsList;
        }

        public SortFilterPageOptions SortFilterPageData { get; private set; }

        public IEnumerable<WordViewModel> WordsList { get; private set; }
    }
}
