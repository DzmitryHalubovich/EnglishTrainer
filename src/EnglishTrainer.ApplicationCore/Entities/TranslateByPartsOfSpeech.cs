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
        [DataType("nvarchar(max)")]
        public string? Adverb { get; set; }

        [Column("adjective")]
        [DataType("nvarchar(max)")]
        public string? Adjective { get; set; }

        [Column("conjunction")]
        [DataType("nvarchar(max)")]
        public string? Conjunction { get; set; }

        [Column("interjection")]
        [DataType("nvarchar(max)")]
        public string? Interjection { get; set; }

        [Column("noun")]
        [DataType("nvarchar(max)")]
        public string? Noun { get; set; }

        [Column("verb")]
        [DataType("nvarchar(max)")]
        public string? Verb { get; set; }

        [Column("preposition")]
        [DataType("nvarchar(max)")]
        public string? Preposition { get; set; }

        [Column("pronoun")]
        [DataType("nvarchar(max)")]
        public string? Pronoun { get; set; }
        
    }
}
