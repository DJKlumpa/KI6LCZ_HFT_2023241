﻿using KI6LCZ_HFT_2023241.Models;
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
        private readonly IRepository<Album> _albumRepository;
        private readonly IRepository<Band> _bandRepository;

        public AlbumLogic(IRepository<Album> albumRepository, IRepository<Band> bandRepository)
        {
            this._albumRepository = albumRepository;
            _bandRepository = bandRepository;
        }

        public void Create(Album t)
        {
            if (string.IsNullOrEmpty(t.AlbumName))
            {
                throw new Exception("Name is empty");
            }

            _albumRepository.Create(t);
        }

        public void Delete(int id)
        {
            _albumRepository.Delete(id);
        }

        public Album Get(int id)
        {
            return _albumRepository.Get(id);
        }

        public IQueryable<Album> GetAll()
        {
            return _albumRepository.ReadAll();
        }

        public void Update(Album t)
        {
            _albumRepository.Update(t);
        }

        public IEnumerable<Album> SpecificBandAlbums(int bandID)
        {
            var albumsForBand = _albumRepository.ReadAll().Where(album => album.BandId == bandID).ToList();
            return albumsForBand;
        }
        public IEnumerable<Album> AlbumBetweenDates(int startDate, int endDate)
        {
            var albumsBetweenDates = (from album in _albumRepository.ReadAll()
                                      join band in _bandRepository.ReadAll() on album.BandId equals band.Id
                                      where band.Year >= startDate && band.Year <= endDate
                                      select album).ToList();

            return albumsBetweenDates;
        }

        public IEnumerable<Album> GetAlbumsWithBandName(string bandName)
        {
            var AlbumsWithBandName = (from album in _albumRepository.ReadAll()
                                      join band in _bandRepository.ReadAll() on album.BandId equals band.Id
                                      where band.BandName == bandName
                                      select album).ToList();
            return AlbumsWithBandName;
        }
    }
}
