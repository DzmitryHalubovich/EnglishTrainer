using EnglishTrainer.ApplicationCore.Entities;

namespace EnglishTrainer.Web.Models
{
    public class DescriptionViewModel
    {
        public int DescriptionId { get; set; }

        public string? AllTranslateVariants { get; set; }

        public List<Example> Examples { get; set; }
    }
}
