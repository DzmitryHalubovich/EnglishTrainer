using EnglishTrainer.ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnglishTrainer.ApplicationCore.Models
{
    public class ExampleViewModel
    {
        public int Id { get; set; }
        [Required]
        public int WordId { get; set; }
        public Word Word { get; set; }

        [Column("engliish_example")]
        [DataType("varchar(max)")]
        public string? EnglishExample { get; set; }

        [Column("russian_translate")]
        [DataType("varchar(max)")]
        public string? RussianExample { get; set; }
    }
}
