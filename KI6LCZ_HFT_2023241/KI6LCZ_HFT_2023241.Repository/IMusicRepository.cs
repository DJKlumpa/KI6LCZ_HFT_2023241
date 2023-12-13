using KI6LCZ_HFT_2023241.Models;
using System.Linq;

namespace KI6LCZ_HFT_2023241.Repository
{
    public interface IMusicRepository
    {
        void Create(Music item);
        void Delete(int id);
        Music Get(int id);
        IQueryable<Music> ReadAll();
        void Update(Music musics);
    }
}