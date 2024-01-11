using KI6LCZ_HFT_2023241.Models;
using KI6LCZ_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KI6LCZ_HFT_2023241.Logic
{
    public class BandLogic : IBandLogic
    {
        private readonly IRepository<Band> _bandRepository;
        private readonly IRepository<Album> _albumRepository;

        public BandLogic(IRepository<Band> bandRepository, IRepository<Album> albumRepository)
        {
            this._bandRepository = bandRepository;
            _albumRepository = albumRepository;
        }

        public void Create(Band t)
        {
            if (string.IsNullOrEmpty(t.BandName))
            {
                throw new Exception("Name is empty");
            }

            _bandRepository.Create(t);
        }

        public void Delete(int id)
        {
            _bandRepository.Delete(id);
        }

        public Band Get(int id)
        {
            return _bandRepository.Get(id);
        }

        public IQueryable<Band> GetAll()
        {
            return _bandRepository.ReadAll();
        }

        public void Update(Band t)
        {
            _bandRepository.Update(t);
        }
        public IEnumerable<Band> BandMoreThanNAlbum(int n)
        {
            var bands = _bandRepository.ReadAll().ToList();
            var albums = _albumRepository.ReadAll().ToList();

            var bandsWithMoreThanNAlbums = bands
                .Where(band => albums.Count(album => album.BandId == band.Id) > n);

            return bandsWithMoreThanNAlbums;

        }
    }
}
