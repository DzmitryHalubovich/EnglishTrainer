using EnglishTrainer.Web.Services.QueryOptions;

namespace EnglishTrainer.Web.Models
{
    public class WordIndexViewModel
    {
        public SortFilterPageOptions SortFilterPageData { get; set; }
        public IEnumerable<WordViewModel> WordsList { get; set; }
        public VerbQueryOptions? Options { get; set; }
    }
}
