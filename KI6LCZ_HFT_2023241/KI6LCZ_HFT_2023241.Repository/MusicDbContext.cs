using KI6LCZ_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace KI6LCZ_HFT_2023241.Repository
{
    public class MusicDbContext : DbContext
    {
        public DbSet<Music> Musics { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Band> Bands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
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
            Genre = "Pop"

        },
        new Music(){Id=2,Title="Kelenföld",AlbumId=1,Length=4.11,Genre="Pop"},
        new Music(){Id=3,Title="we came as monkeys",AlbumId=4,Length=5.03,Genre="Metal"},
        new Music(){Id=4,Title="Inside the Dark",AlbumId=4,Length=3.16,Genre="Metal"},
        new Music(){Id=5,Title="Latin szótárak",AlbumId=2,Length=6.07,Genre="Latin"},

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
            Genre = "Pop"

        },
        new Album(){Id=2,AlbumName="Sunday After Chruch",BandId=1,Year=2002,Genre="Electronic Dance"},
        new Album(){Id=3,AlbumName="English Hunglish művészete",BandId=1,Year=2004,Genre="Electronic Dance"},
        new Album(){Id=4,AlbumName="Dark Shadows EP",BandId=2,Year=2004,Genre="Metal"},
        new Album(){Id=5,AlbumName="Getting Away with Toxic",BandId=2,Year=2006,Genre="Metal"},
            });
            modelBuilder.Entity<Band>().HasData(new Band[]
            {
        new Band()
        {
            Id = 1,
            BandName="Vöröstollas",
            Year=2000,
            AlbumCounter = 9
        },
        new Band(){Id=2,BandName="Dark Shadows",Year=2003, AlbumCounter = 5},
        new Band(){Id=3,BandName="Unikornisok",Year=2010, AlbumCounter = 4}
            });
        }
    }
}
