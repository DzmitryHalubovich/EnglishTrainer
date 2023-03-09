using EnglishTrainer.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer.ApplicationCore.Models
{
    public class PartsOfSpeechViewModel
    {
        public int Id { get; set; }
        public int WordId { get; set; }
        public Word Word { get; set; }
        public string? Adverb { get; set; }

        public string? Adjective { get; set; }
        public string? Conjunction { get; set; }
        public string? Interjection { get; set; }

        public string? Noun { get; set; }

        public string? Verb { get; set; }

        public string? Preposition { get; set; }

        public string? Pronoun { get; set; }
    }
}
