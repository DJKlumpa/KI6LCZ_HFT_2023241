using KI6LCZ_HFT_2023241.Models;
using System.Linq;

namespace KI6LCZ_HFT_2023241.Repository
{
    public interface IBandRepository
    {
        void Create(Band item);
        void Delete(int id);
        Band Get(int id);
        IQueryable<Band> ReadAll();
        void Update(Band bands);
    }
}