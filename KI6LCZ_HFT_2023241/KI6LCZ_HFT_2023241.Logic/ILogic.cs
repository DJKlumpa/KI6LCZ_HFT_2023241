using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KI6LCZ_HFT_2023241.Logic
{
    public interface ILogic<T> where T : class
    {
        void Create(T t);
        T Get(int id);
        IQueryable<T> GetAll();
        void Delete(int id);
        void Update(T t);
    }
}
