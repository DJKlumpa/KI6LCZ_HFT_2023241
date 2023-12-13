using KI6LCZ_HFT_2023241.Models;
using System.Collections.Generic;
using System.Linq;

namespace KI6LCZ_HFT_2023241.Logic
{
    public interface IMusicLogic
    {
        void Create(Music t);
        void Delete(int id);
        Music Get(int id);
        IQueryable<Music> GetAll();
        IEnumerable<Music> MusicWhereAlbumAfter1991();
        IEnumerable<Music> MusicWhereAlbumGenrePop();
        IEnumerable<Music> MusicWhereAlbumID2();
        void Update(Music t);
    }
}