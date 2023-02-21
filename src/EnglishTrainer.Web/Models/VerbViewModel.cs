﻿using EnglishTrainer.ApplicationCore.Entities;

namespace EnglishTrainer.Web.Models
{
    public sealed class VerbViewModel
    {
        public int Id { get; set; }

        public string Infinitive { get; set; }

        public string PastSimple { get; set; }

        public string PastParticiple { get; set; }
        public Description? Description { get; set; }

        public string ShortTranslate { get; set; }
    }
}
