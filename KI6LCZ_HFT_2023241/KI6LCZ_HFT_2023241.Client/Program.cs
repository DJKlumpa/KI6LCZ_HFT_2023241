using KI6LCZ_HFT_2023241.Models;
using System;
using KI6LCZ_HFT_2023241.Repository;
using KI6LCZ_HFT_2023241.Logic;
using System.Linq;

namespace KI6LCZ_HFT_2023241.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Magyaroknak jó napot! \t\tCigányoknak jó melót!");
            Music m = new Music();
            MusicDbContext db = new MusicDbContext();

            IRepository<Music> musicRepository = new MusicRepository(db);
            IRepository<Album> albumRepository = new AlbumRepository(db);
            IRepository<Band> bandRepository = new BandRepository(db);

            ILogic<Music> musicLogic = new MusicLogic(musicRepository);
            ILogic<Album> albumLogic = new AlbumLogic(albumRepository);
            ILogic<Band> bandLogic = new BandLogic(bandRepository);

            var musics = musicLogic.GetAll();

            Music mtemp = new Music()
            {
                Title = "Csokis narancs",
                AlbumId = 1,
                Length = 2.19,
                Genre = Genre.Electronic_Dance
            };

            musicLogic.Create(mtemp);
            var musicss = musicLogic.GetAll();
        }
    }
}
