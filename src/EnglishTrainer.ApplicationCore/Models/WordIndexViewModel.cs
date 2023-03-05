using EnglishTrainer.ApplicationCore.QueryOptions;

namespace EnglishTrainer.ApplicationCore.Models
{
    public class WordIndexViewModel
    {
        public SortFilterPageOptions SortFilterPageData { get; set; }
        public IEnumerable<WordViewModel> WordsList { get; set; }
        public VerbQueryOptions? Options { get; set; }
    }
}
