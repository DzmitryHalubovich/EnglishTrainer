using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer.ApplicationCore.Entities
{
    [Table("examples")]
    public sealed class Example : BaseModel
    {
        [Required]
        public int WordId { get; set; }
        public Word Word { get; set; }

        [Required]
        [Column("engliish_example")]
        [DataType("varchar(max)")]
        public string EnglishExample { get; set; }

        [Column("russian_translate")]
        [DataType("varchar(max)")]
        public string? RussianExample { get; set; }
    }
}
