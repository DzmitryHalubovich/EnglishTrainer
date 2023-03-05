
using EnglishTrainer.ApplicationCore.QueryOptions;

namespace EnglishTrainer.ApplicationCore.Models
{
    public sealed class VerbIndexViewModel
    {
        public SortFilterPageOptions SortFilterPageData { get; set; }
        public IEnumerable<VerbViewModel> VerbsList { get; set; }
        public VerbQueryOptions? Options { get; set; }
    }
}
