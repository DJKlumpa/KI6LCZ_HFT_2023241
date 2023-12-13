using KI6LCZ_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KI6LCZ_HFT_2023241.Repository
{
    public class BandRepository : IRepository<Band>
    {
        private readonly MusicDbContext _musicDb;
        public BandRepository(MusicDbContext musicDb)
        {
            this._musicDb = musicDb;
        }
        public void Create(Band item)
        {
            _musicDb.Add(item);
            _musicDb.SaveChanges();
        }

        public void Delete(int id)
        {
            Band toDelete = Get(id);
            _musicDb.Remove(toDelete);
            _musicDb.SaveChanges();
        }

        public Band Get(int id)
        {
            return _musicDb.Bands.SingleOrDefault(X => X.Id == id);
        }

        public IQueryable<Band> ReadAll()
        {
            return _musicDb.Bands.AsQueryable();
        }

        public void Update(Band bands)
        {
            var bandUpdate = Get(bands.Id);
            bandUpdate.BandName = bands.BandName;
            bandUpdate.Year = bands.Year;
            bandUpdate.Albums = bands.Albums;
            _musicDb.SaveChanges();
        }
    }
}
