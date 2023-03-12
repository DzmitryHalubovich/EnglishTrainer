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
        [DataType("nvarchar(max)")]
        public string TranslateVariants { get; set; }
        public string? Description { get; set; }
        public IList<Example>? Examples { get; set; } = new List<Example>();
    }
}
