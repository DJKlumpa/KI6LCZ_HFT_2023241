using KI6LCZ_HFT_2023241.Models;
using System.Collections.Generic;
using System.Linq;

namespace KI6LCZ_HFT_2023241.Logic
{
    public interface IAlbumLogic
    {
        IEnumerable<Album> BandBetween91and2009();
        IEnumerable<Album> BandID2Albums();
        IEnumerable<Album> BandMoreThan1Album();
        void Create(Album t);
        IEnumerable<Album> DarkShadowsAlbumbs();
        void Delete(int id);
        Album Get(int id);
        IQueryable<Album> GetAll();
        void Update(Album t);
    }
}