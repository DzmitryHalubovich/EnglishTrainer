using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Interfaces;

namespace EnglishTrainer.Infrastructure.Services
{
    public sealed class VerbRepository : IRepository<Verb>
    {
        IList<Verb> _verbs = new List<Verb>()
        {
            new Verb() {Id =1 , Infinitive="be", PastSimple = "was/were", PastParticiple = "been", TranslateRu = "быть/являться" },
            new Verb() {Id =2 , Infinitive="beat", PastSimple = "beat", PastParticiple = "beaten", TranslateRu = "бить/колотить" },
            new Verb() {Id =3 , Infinitive="become", PastSimple = "became", PastParticiple = "become", TranslateRu = "становиться" },
            new Verb() {Id =4 , Infinitive="begin", PastSimple = "began", PastParticiple = "begun", TranslateRu = "начинать" },
            new Verb() {Id =5 , Infinitive="bend", PastSimple = "bent", PastParticiple = "bent", TranslateRu = "гнуть" },
            new Verb() {Id =6 , Infinitive="bet", PastSimple = "bet", PastParticiple = "bet", TranslateRu = "держать пари" },
        };

        public VerbRepository(IRepository<Verb> verbRepository)
        {
            //_verbRepository=verbRepository;
        }

        public IEnumerable<Verb> GetAll()
        {
            return _verbs;
        }

        public Verb? GetById(int id)
        {
            var verb = _verbs.FirstOrDefault(x => x.Id == id);
            return verb;
        }
    }
}
