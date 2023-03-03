using EnglishTrainer.ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations;

namespace EnglishTrainer.Web.Models
{
    public class WordViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string TranslateVariants { get; set; }

        public IList<Example> Examples { get; set; }
        public TranslateByPartsOfSpeech PartsOfSpeech { get; set; }
    }
}
