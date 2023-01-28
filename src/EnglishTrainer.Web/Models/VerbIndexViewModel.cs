namespace EnglishTrainer.Web.Models
{
    public sealed class VerbIndexViewModel
    {
        public SortFilterPageOptions SortFilterPageData { get; set; }
        public IEnumerable<VerbViewModel> VerbsList { get; set; }
    }
}
