using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnglishTrainer.ApplicationCore.Entities
{
    [Table("irregular_verbs")]
    public sealed class IrregularVerb : BaseModel
    {
        [Column("infinitive")]
        [DataType("varchar(max)")]
        public string Infinitive { get; set; }

        [Column("past_simple")]
        [DataType("varchar(max)")]
        public string PastSimple { get; set; }

        [Column("past_participle")]
        [DataType("varchar(max)")]
        public string PastParticiple { get; set; }

        [Column("short_translate")]
        [DataType("varchar(max)")]
        public string ShortTranslate { get; set; }

        public IrregularVerb() { }

        public IrregularVerb(string infinitive, string pastSimple, string pastParticiple, string shortTranslate)
        {
            Infinitive = infinitive;
            PastSimple = pastSimple;
            PastParticiple = pastParticiple;
            ShortTranslate = shortTranslate;
        }
    }
}
