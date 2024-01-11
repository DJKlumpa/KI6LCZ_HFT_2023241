using KI6LCZ_HFT_2023241.Models;
using System.Collections.Generic;
using System.Linq;

namespace KI6LCZ_HFT_2023241.Logic
{
    public interface IMusicLogic : ILogic<Music>
    {      
        IEnumerable<Music> MusicWithGenre(Genre genre);
    }
}