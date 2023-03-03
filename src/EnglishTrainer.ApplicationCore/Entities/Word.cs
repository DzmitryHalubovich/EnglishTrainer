﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer.ApplicationCore.Entities
{
    public class Word : BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string TranslateVariants { get; set; }


        public IList<Example> Examples { get; set; }
        public TranslateByPartsOfSpeech PartsOfSpeech { get; set; }

    }
}