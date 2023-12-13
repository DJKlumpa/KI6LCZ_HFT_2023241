using KI6LCZ_HFT_2023241.Models;
using System.Linq;

namespace KI6LCZ_HFT_2023241.Logic
{
    public interface IBandLogic
    {
        void Create(Band t);
        void Delete(int id);
        Band Get(int id);
        IQueryable<Band> GetAll();
        void Update(Band t);
    }
}