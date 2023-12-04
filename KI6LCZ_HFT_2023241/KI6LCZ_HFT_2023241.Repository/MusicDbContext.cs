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
        void Update(Music music);
        void Delete(int id);
    }
    public class MusicDbContext : DbContext
    {
        public DbSet<Music> Musics { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Band> Bands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                //string temp = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\music.mdf;Integrated Security=True;MultipleActiveResultSets=true";
                //builder
                //    .UseLazyLoadingProxies()
                //    .UseSqlServer(temp);

                builder.UseLazyLoadingProxies().UseInMemoryDatabase("musicDB");
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
            Id = 1,
            Title = "Keserű csokis eper",
            AlbumId = 4,
            Length = 3.39,
            Genre = Genre.Pop

        },
        new Music(){Id=2,Title="Kelenföld",AlbumId=1,Length=4.11,Genre=Genre.Pop},
        new Music(){Id=3,Title="we came as monkeys",AlbumId=4,Length=5.03,Genre=Genre.Metal},
        new Music(){Id=4,Title="Inside the Dark",AlbumId=4,Length=3.16,Genre=Genre.Metal},
        new Music(){Id=5,Title="Latin szótárak",AlbumId=2,Length=6.07,Genre=Genre.Latin},

            }

                );
            modelBuilder.Entity<Album>().HasData(new Album[]
            {
        new Album()
        {
            Id=1,
            AlbumName = "Fergeteges Szombat reggel",
            BandId = 1,
            Year=2001,
            Genre = Genre.Pop

        },
        new Album(){Id=2,AlbumName="Sunday After Chruch",BandId=1,Year=2002,Genre=Genre.Electronic_Dance},
        new Album(){Id=3,AlbumName="English Hunglish művészete",BandId=1,Year=2004,Genre=Genre.Electronic_Dance},
        new Album(){Id=4,AlbumName="Dark Shadows EP",BandId=2,Year=2004,Genre=Genre.Metal},
        new Album(){Id=5,AlbumName="Getting Away with Toxic",BandId=2,Year=2006,Genre=Genre.Metal},
            });
            modelBuilder.Entity<Band>().HasData(new Band[]
            {
        new Band()
        {
            Id = 1,
            BandName="Vöröstollas",
            Year=2000
        },
        new Band(){Id=2,BandName="Dark Shadows",Year=2003},
        new Band(){Id=3,BandName="Unikornisok",Year=2010}
            });
        }
    }
}
