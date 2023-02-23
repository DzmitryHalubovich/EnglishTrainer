﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer.ApplicationCore.Entities
{
    public sealed class Description : BaseModel
    {

        public string? AllTranslateVariants { get; set; }


        public List<Example> Examples { get; set; }
    }
}
