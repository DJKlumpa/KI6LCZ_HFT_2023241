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
                new Music(){Id=1,Title="Bloody Mary",AlbumId=2,Length=3.55,Genre="Pop" },
                new Music(){Id=2,Title="Kelenföld",AlbumId=1,Length=4.11,Genre="Pop"},
                new Music(){Id=3,Title="we came as monkeys",AlbumId=4,Length=5.03,Genre="Metal"},
                new Music(){Id=4,Title="Inside the Dark",AlbumId=4,Length=3.16,Genre="Metal"},
                new Music(){Id=5,Title="Latin szótárak",AlbumId=2,Length=6.07,Genre="Latin"}
            };            
            bandList = new List<Band> {
                new Band(){Id=1,BandName="Dark Shadows",Year=2003},
                new Band(){Id=2,BandName="Unikornisok",Year=2010}
            };
            albumList = new List<Album> {
                new Album(){Id=1,AlbumName="Sunday After Chruch",BandId=1,Year=2002,Genre="Electronic Dance"},
                new Album(){Id=2,AlbumName="English Hunglish művészete",BandId=1,Year=2004,Genre="Electronic Dance"},
                new Album(){Id=3,AlbumName="Dark Shadows EP",BandId=2,Year=2004,Genre="Metal"},
                new Album(){Id=4,AlbumName="Getting Away with Toxic",BandId=2,Year=2006,Genre="Metal"}
            };

            musicMock.Setup(x => x.ReadAll()).Returns(musicList.AsQueryable());
            albumMock.Setup(x => x.ReadAll()).Returns(albumList.AsQueryable());
            bandMock.Setup(x => x.ReadAll()).Returns(bandList.AsQueryable());

            musicLogic = new MusicLogic(musicMock.Object);
            albumLogic = new AlbumLogic(albumMock.Object,bandMock.Object);
            bandLogic = new BandLogic(bandMock.Object);
        }

        [Test]
        public static void TestMusicAll()
        {
            List<Music> testResult = musicList;

            var result = musicLogic.GetAll();

            Assert.That(result.Count, Is.EqualTo(testResult.Count));
            Assert.That(result, Is.EquivalentTo(testResult));
        }
        [Test]
        public static void TestAlbumAll()
        {
            List<Album> testResult = albumList;

            var result = albumLogic.GetAll();

            Assert.That(result.Count, Is.EqualTo(testResult.Count));
            Assert.That(result, Is.EquivalentTo(testResult));
        }
        [Test]
        public static void TestBandAll()
        {
            List<Band> testResult = bandList;

            var result = bandLogic.GetAll();

            Assert.That(result.Count, Is.EqualTo(testResult.Count));
            Assert.That(result, Is.EquivalentTo(testResult));
        }
        [TestCase(0)]
        [TestCase(1)]
        public static void TestUpdateMusic(int id)
        {
            Music newMusic = new Music() { Id = id, Title = "ZSZSZSZSZS Mi ez valami bboy találkozó?", AlbumId = 1, Length = 2.55, Genre = "HipHop" };

            musicMock.Setup(repo => repo.Update(newMusic)).Verifiable();
            musicLogic.Update(newMusic);
            musicMock.Verify(repo => repo.Update(newMusic));
        }
        [TestCase(0)]
        [TestCase(1)]
        public static void TestUpdateAlbum(int id)
        {
            Album newAlbum = new Album() { Id = id, AlbumName = "ZSZSZSZSZS Mi ez valami battle of the year?", BandId = 1, Year = 2016, Genre = "HipHop" };

            albumMock.Setup(repo => repo.Update(newAlbum)).Verifiable();
            albumLogic.Update(newAlbum);
            albumMock.Verify(repo => repo.Update(newAlbum));
        }
        [TestCase(0)]
        [TestCase(1)]
        public static void TestUpdateBand(int id)
        {
            Band newBand = new Band() { Id = id, BandName = "BBOYING", Year = 1998 };

            bandMock.Setup(repo => repo.Update(newBand)).Verifiable();
            bandLogic.Update(newBand);
            bandMock.Verify(repo => repo.Update(newBand));
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(-1)]
        public static void TestDeleteMusic(int id)
        {
            musicMock.Setup(repo => repo.Delete(id)).Verifiable();
            musicLogic.Delete(id);
            musicMock.Verify(repo => repo.Delete(id));
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(-1)]
        public static void TestDeleteAlbum(int id)
        {
            albumMock.Setup(repo => repo.Delete(id)).Verifiable();
            albumLogic.Delete(id);
            albumMock.Verify(repo => repo.Delete(id));
        }
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(-1)]
        public static void TestDeleteBand(int id)
        {
            bandMock.Setup(repo => repo.Delete(id)).Verifiable();
            bandLogic.Delete(id);
            bandMock.Verify(repo => repo.Delete(id));
        }



        [Test]
        public void BandBetweenDates_Test()
        {
            var result = albumLogic.BandBetweenDates(1991, 2009).ToArray();
            Assert.That(result.Count, Is.EqualTo(1));
        }
        [Test]
        public void SpecificBandAlbums_Test()
        {
            var result = albumLogic.SpecificBandAlbums(2).ToArray();
            Assert.That(result.Count, Is.EqualTo(2));
        }

        


    }


}
