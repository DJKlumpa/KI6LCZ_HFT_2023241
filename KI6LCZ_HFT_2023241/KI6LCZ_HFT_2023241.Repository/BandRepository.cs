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
        protected MusicDbContext musicDb;
        public BandRepository(MusicDbContext ctx)
        {
            musicDb = ctx;
        }
        public void Create(Band item)
        {
            //musicDb.Set<Band>().Add(item);
            musicDb.Add(item);
            musicDb.SaveChanges();
        }

        public void Delete(int id)
        {
            Band toDelete = Get(id);
            musicDb.Remove(toDelete);
            musicDb.SaveChanges();
        }

        public Band Get(int id)
        {
            return musicDb.Bands.SingleOrDefault(X => X.Id == id);
        }

        public IQueryable<Band> ReadAll()
        {
            return musicDb.Bands.AsQueryable();
        }

        public void Update(Band bands)
        {
            var bandUpdate = Get(bands.Id);
            bandUpdate.BandName = bands.BandName;
            bandUpdate.Year = bands.Year;
            bandUpdate.Albums = bands.Albums;
            musicDb.SaveChanges();
        }
    }
}
