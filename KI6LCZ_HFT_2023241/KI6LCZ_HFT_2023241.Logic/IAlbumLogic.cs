using KI6LCZ_HFT_2023241.Models;
using System.Collections.Generic;
using System.Linq;

namespace KI6LCZ_HFT_2023241.Logic
{
    public interface IAlbumLogic : ILogic<Album>
    {
        IEnumerable<Album> AlbumBetweenDates(int startDate, int endDate);
        IEnumerable<Album> SpecificBandAlbums(int bandID);
        IEnumerable<Album> GetAlbumsWithBandName(string bandName);
    }
}