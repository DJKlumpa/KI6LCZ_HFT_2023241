using KI6LCZ_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace KI6LCZ_HFT_2023241.Repository
{
    public interface IMusicRepository
    {
        void Create(Music music);
        Music Listen(int id);
        IQueryable<Music> ReadAll();
        void Update (Music music);
        void Delete(int id);
    }
    public class MusicDbContext : DbContext
    {
        DbSet<Music> Musics { get; set; }
        DbSet<Album> Albums { get; set; }
        DbSet<Band> Bands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if(!builder.IsConfigured)
            {
                string temp = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\music.mdf;Integrated Security=True;MultipleActiveResultSets=true";
                builder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(temp);
            }
        }
    }
}
