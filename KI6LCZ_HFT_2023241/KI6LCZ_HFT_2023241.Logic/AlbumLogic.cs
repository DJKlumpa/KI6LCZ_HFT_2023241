using KI6LCZ_HFT_2023241.Models;
using KI6LCZ_HFT_2023241.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KI6LCZ_HFT_2023241.Logic
{
    public class AlbumLogic : IAlbumLogic
    {
        IAlbumRepository albumRepository;

        public AlbumLogic(IAlbumRepository albumRepository)
        {
            this.albumRepository = albumRepository;
        }

        public void Create(Album t)
        {
            albumRepository.Create(t);
        }

        public void Delete(int id)
        {
            albumRepository.Delete(id);
        }

        public Album Get(int id)
        {
            return albumRepository.Get(id);
        }

        public IQueryable<Album> GetAll()
        {
            return albumRepository.ReadAll();
        }

        public void Update(Album t)
        {
            albumRepository.Update(t);
        }

        public IEnumerable<Album> BandID2Albums()
        {
            var albumsForBand = albumRepository.ReadAll().Where(album => album.BandId == 2).ToList();
            return albumsForBand;
        }
        public IEnumerable<Album> BandBetween91and2009()
        {
            var albumsBetweenYears = albumRepository.ReadAll().Where(album => album.Band.Year >= 1991 && album.Band.Year <= 2009).ToList();
            return albumsBetweenYears;
        }
        public IEnumerable<Album> BandMoreThan1Album()
        {
            var albumsMoreThanOne = albumRepository.ReadAll().Where(album => album.Band.AlbumCounter > 1).ToList();
            return albumsMoreThanOne;
        }
        public IEnumerable<Album> DarkShadowsAlbumbs()
        {
            var darkShadowsAlbums = albumRepository.ReadAll().Where(album => album.Band.BandName == "Dark Shadows").ToList();
            return darkShadowsAlbums;
        }
    }
}
