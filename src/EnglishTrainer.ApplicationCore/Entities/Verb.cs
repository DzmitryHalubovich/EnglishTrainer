namespace EnglishTrainer.ApplicationCore.Entities
{
    public sealed class Verb
    {
        public int Id { get; set; }

        public string Infinitive { get; set; }

        public string PastSimple { get; set; } 

        public string PastParticiple { get; set; }

        public string TranslateRu { get; set; }

        public Verb()
        {

        }

        public Verb(string infinitive, string pastSimple, string pastParticiple, string transtaleRu)
        {
            Infinitive = infinitive;
            PastSimple = pastSimple;
            PastParticiple = pastParticiple;
            TranslateRu = transtaleRu;
        }
    }
}
