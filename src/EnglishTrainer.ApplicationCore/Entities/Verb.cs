namespace EnglishTrainer.ApplicationCore.Entities
{
    public sealed class Verb : BaseModel
    {
        public string Infinitive { get; set; }

        public string PastSimple { get; set; } 

        public string PastParticiple { get; set; }

        public string ShortTranslate { get; set; }

        
        public int? DescriptionId { get; set; }
        public Description? Description { get; set; }
         

        public Verb()
        {

        }

        public Verb(string infinitive, string pastSimple, string pastParticiple, string shortTranslate)
        {
            Infinitive = infinitive;
            PastSimple = pastSimple;
            PastParticiple = pastParticiple;
            ShortTranslate = shortTranslate;
        }
    }
}
