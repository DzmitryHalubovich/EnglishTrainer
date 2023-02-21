using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer.ApplicationCore.Entities
{
    public sealed class Example
    {
        [Key]
        public int ExampleId { get; set; }

        public int DescriptionId { get; set; }
        public Description Description { get; set; }

        public string EnglishExample { get; set; }
        public string RussianExample { get; set; }
    }
}
