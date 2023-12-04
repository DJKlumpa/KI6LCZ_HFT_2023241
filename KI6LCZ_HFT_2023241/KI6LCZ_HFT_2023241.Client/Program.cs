using KI6LCZ_HFT_2023241.Models;
using System;
using KI6LCZ_HFT_2023241.Repository;
using KI6LCZ_HFT_2023241.Logic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KI6LCZ_HFT_2023241.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string loading = "Magyaroknak jó napot!\nCigányoknak jó munkát!";
            int maxTimeout = 8000;
            int timeoutCounter = 0;
            //Console.WriteLine("Magyaroknak jó napot! \t\tCigányoknak jó munkát!");
            Random rnd = new Random();

            Task t = new Task(() =>
            {
                foreach (char item in loading)
                {
                    if (timeoutCounter >= maxTimeout)
                    {
                        break;
                    }

                    Console.Write(item);
                    int timeout = rnd.Next(0, maxTimeout - timeoutCounter);
                    timeoutCounter += timeout;
                    Thread.Sleep(timeout);
                }
            }, TaskCreationOptions.LongRunning);

            t.Start();
            
            Console.WriteLine("asd");
            Music m = new Music();
            MusicDbContext db = new MusicDbContext();

            IRepository<Music> musicRepository = new MusicRepository(db);
            IRepository<Album> albumRepository = new AlbumRepository(db);
            IRepository<Band> bandRepository = new BandRepository(db);

            ILogic<Music> musicLogic = new MusicLogic(musicRepository);
            ILogic<Album> albumLogic = new AlbumLogic(albumRepository);
            ILogic<Band> bandLogic = new BandLogic(bandRepository);

            var musics = musicLogic.GetAll();
            t.Wait();

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
