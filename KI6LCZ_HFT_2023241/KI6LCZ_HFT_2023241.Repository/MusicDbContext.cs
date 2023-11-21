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
        public DbSet<Music> Musics { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Band> Bands { get; set; }

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

        public MusicDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Music>()
                .HasOne(music => music.Album)
                .WithMany(album => album.Musics)
                .HasForeignKey(music => music.AlbumId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Album>()
                .HasOne(album => album.Band)
                .WithMany(band => band.Albums)
                .HasForeignKey(album => album.BandId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Music>().HasData(new Music[]
            {
        new Music()
        {
            Id = 7,
            Title = "Keserű csokis eper",
            AlbumId = 4,
            Length = 3.39,
            Genre = Genre.Pop

        }
            }

                );
            modelBuilder.Entity<Album>().HasData(new Album[]
            {
        new Album()
        {
            Id=4,
            AlbumName = "Fergeteges Szombat reggel",
            BandId = 1,
            Year=2001,
            Genre = Genre.Pop

        }
            });
            modelBuilder.Entity<Band>().HasData(new Band[]
            {
        new Band()
        {
            Id = 1,
            BandName="Piros tollak",
            Year=2000
        }
            });
        }
    }
}
