using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer.ApplicationCore.Entities
{
    public class Picture : BaseModel
    {
        public string Name { get; set; }
        public string Path { get; set; }

    }
}
