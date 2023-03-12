using EnglishTrainer.ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations;

namespace EnglishTrainer.ApplicationCore.Models
{
    public class WordViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType("varchar(max)")]
        public string TranslateVariants { get; set; }

        public IList<Example>? Examples { get; set; } = new List<Example>();
        public TranslateByPartsOfSpeech PartsOfSpeech { get; set; }
    }
}
