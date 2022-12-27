using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer.ApplicationCore.Interfaces
{
    public interface IRepository <T> where T : class
    {
        IEnumerable<T> GetAll();
        T? GetById(int id);
    }
}
