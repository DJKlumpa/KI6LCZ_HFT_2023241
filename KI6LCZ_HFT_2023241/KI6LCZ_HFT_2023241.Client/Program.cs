using KI6LCZ_HFT_2023241.Models;
using System;
using KI6LCZ_HFT_2023241.Repository;
using System.Linq;

namespace KI6LCZ_HFT_2023241.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Music m = new Music();
            MusicDbContext db = new MusicDbContext();
            //IRepository<Music> musicRepository = new MusicRepository();
        }
    }
}
