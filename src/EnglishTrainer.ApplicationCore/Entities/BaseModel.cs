using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer.ApplicationCore.Entities
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}
