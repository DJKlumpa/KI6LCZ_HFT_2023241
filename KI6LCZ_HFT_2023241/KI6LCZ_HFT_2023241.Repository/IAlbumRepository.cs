using KI6LCZ_HFT_2023241.Models;
using System.Linq;

namespace KI6LCZ_HFT_2023241.Repository
{
    public interface IAlbumRepository
    {
        void Create(Album item);
        void Delete(int id);
        Album Get(int id);
        IQueryable<Album> ReadAll();
        void Update(Album albums);
    }
}