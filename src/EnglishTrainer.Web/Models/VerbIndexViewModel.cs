using EnglishTrainer.ApplicationCore.QueryOptions;
using EnglishTrainer.Web.Services.QueryOptions;

namespace EnglishTrainer.Web.Models
{
    public sealed class VerbIndexViewModel
    {
        public SortFilterPageOptions SortFilterPageData { get; set; }
        public IEnumerable<VerbViewModel> VerbsList { get; set; }
        public VerbQueryOptions? Options { get; set; }
    }
}
