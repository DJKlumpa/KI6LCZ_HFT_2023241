using KI6LCZ_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KI6LCZ_HFT_2023241.Repository
{
    public interface IRepository<T> where T : class
    {
        void Create(T t);
        T Get(int id);
        IQueryable<T> ReadAll();
        void Update(T t);
        void Delete(int id);
    }
}
