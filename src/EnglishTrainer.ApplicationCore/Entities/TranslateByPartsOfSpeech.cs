using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer.ApplicationCore.Entities
{
    [Table("various_translations")]
    public class TranslateByPartsOfSpeech : BaseModel
    {

        public int WordId { get; set; }
        public Word Word { get; set; }

        [Column("adverb")]
        [DataType("varchar(max)")]
        public string? Adverb { get; set; }

        [Column("adjective")]
        [DataType("varchar(max)")]
        public string? Adjective { get; set; }

        [Column("conjunction")]
        [DataType("varchar(max)")]
        public string? Conjunction { get; set; }

        [Column("interjection")]
        [DataType("varchar(max)")]
        public string? Interjection { get; set; }

        [Column("noun")]
        [DataType("varchar(max)")]
        public string? Noun { get; set; }

        [Column("verb")]
        [DataType("varchar(max)")]
        public string? Verb { get; set; }

        [Column("preposition")]
        [DataType("varchar(max)")]
        public string? Preposition { get; set; }

        [Column("pronoun")]
        [DataType("varchar(max)")]
        public string? Pronoun { get; set; }
        
    }
}
