using KI6LCZ_HFT_2023241.Logic;
using KI6LCZ_HFT_2023241.Models;
using KI6LCZ_HFT_2023241.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KI6LCZ_HFT_2023241.Test
{
    public class Tester
    {
        static MusicLogic musicLogic;
        static BandLogic bandLogic;
        static AlbumLogic albumLogic;

        static List<Music> musicList;
        static List<Band> bandList;
        static List<Album> albumList;

        static Mock<IRepository<Music>> musicMock;
        static Mock<IRepository<Album>> albumMock;
        static Mock<IRepository<Band>> bandMock;

        [SetUp]
        public static void TestSetUp()
        {
            musicMock = new Mock<IRepository<Music>>();
            albumMock = new Mock<IRepository<Album>>();
            bandMock = new Mock<IRepository<Band>>();

            musicList = new List<Music> {
               new Music(){Id=1,Title="Bloody Mary",AlbumId=2,Length=3.55,Genre=Genre.Pop },
                new Music(){Id=2,Title="Kelenföld",AlbumId=1,Length=4.11,Genre=Genre.Pop},
                new Music(){Id=3,Title="we came as monkeys",AlbumId=4,Length=5.03,Genre=Genre.Metal},
                new Music(){Id=4,Title="Inside the Dark",AlbumId=4,Length=3.16,Genre=Genre.Metal},
                new Music(){Id=5,Title="Latin szótárak",AlbumId=2,Length=6.07,Genre=Genre.Latin}
            };            
            bandList = new List<Band> {
                new Band(){Id=1,BandName="Dark Shadows",Year=2003},
                new Band(){Id=2,BandName="Unikornisok",Year=2010}
            };
            albumList = new List<Album> {
                new Album(){Id=1,AlbumName="Sunday After Chruch",BandId=1,Year=2002,Genre=Genre.Electronic_Dance},
                new Album(){Id=2,AlbumName="English Hunglish művészete",BandId=1,Year=2004,Genre=Genre.Electronic_Dance},
                new Album(){Id=3,AlbumName="Dark Shadows EP",BandId=2,Year=2004,Genre=Genre.Metal},
                new Album(){Id=4,AlbumName="Getting Away with Toxic",BandId=2,Year=2006,Genre=Genre.Metal}
            };

            musicMock.Setup(x => x.ReadAll()).Returns(musicList.AsQueryable());
            albumMock.Setup(x => x.ReadAll()).Returns(albumList.AsQueryable());
            bandMock.Setup(x => x.ReadAll()).Returns(bandList.AsQueryable());

            musicLogic = new MusicLogic(musicMock.Object, albumMock.Object);
            albumLogic = new AlbumLogic(albumMock.Object, bandMock.Object);
            bandLogic = new BandLogic(bandMock.Object, albumMock.Object);
        }

        [Test]
        public void AlbumBetweenDates_Test()
        {
            var result = albumLogic.AlbumBetweenDates(1991, 2009).ToArray();
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void SpecificBandAlbums_Test()
        {
            var result = albumLogic.SpecificBandAlbums(2).ToArray();
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void BandMoreThanNAlbum_Test()
        {
            var result = bandLogic.BandMoreThanNAlbum(1).ToArray();
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetAlbumsWithBandName_Test()
        {
            var result = albumLogic.GetAlbumsWithBandName("Unikornisok").ToArray();
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void MusicWithGenre_Test()
        {
            var result = musicLogic.MusicWithGenre(Genre.Metal).ToArray();
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void MusicCreate_Test()
        {
            Music m = new Music() { Id = 99, Title = "TESt MUSIC", AlbumId = 2, Length = 3.55, Genre = Genre.Country };

            Assert.DoesNotThrow(() => musicLogic.Create(m));
        }

        [Test]
        public void MusicCreateException_Test()
        {
            Music m = new Music() { Id = 99, Title = "", AlbumId = 2, Length = 3.55, Genre = Genre.Country };

            Assert.Throws<Exception>(() => musicLogic.Create(m));
        }

        [Test]
        public void AlbumCreate_Test()
        {
            Album a = new Album() { Id = 99, AlbumName = "TEST ALBUM", BandId = 1, Year = 9999, Genre = Genre.Metal };

            Assert.DoesNotThrow(() => albumLogic.Create(a));
        }

        [Test]
        public void AlbumCreateException_Test()
        {
            Album a = new Album() { Id = 99, AlbumName = "", BandId = 1, Year = 999, Genre = Genre.Metal };

            Assert.Throws<Exception>(() => albumLogic.Create(a));
        }

        [Test]
        public void BandCreate_Test()
        {
            Band b = new Band() { Id = 99, BandName = "TEST BAND", Year = 999 };


            Assert.DoesNotThrow(() => bandLogic.Create(b));
        }

        [Test]
        public void BandCreateException_Test()
        {
            Band b = new Band() { Id = 99, BandName = "", Year = 999 };

            Assert.Throws<Exception>(() => bandLogic.Create(b));
        }


    }


}
