using KI6LCZ_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KI6LCZ_HFT_2023241.Repository
{
    public class AlbumRepository : IRepository<Album>
    {
        //mindenhol
        private readonly MusicDbContext _musicDb;
        public AlbumRepository(MusicDbContext musicDb)
        {
            this._musicDb = musicDb;
        }
        public void Create(Album item)
        {
            _musicDb.Add(item);
            _musicDb.SaveChanges();
        }

        public void Delete(int id)
        {
            Album toDelete = Get(id);
            _musicDb.Remove(toDelete);
            _musicDb.SaveChanges();
        }

        public Album Get(int id)
        {
            return _musicDb.Albums.SingleOrDefault(X => X.Id == id);
        }

        public IQueryable<Album> ReadAll()
        {
            return _musicDb.Albums.AsQueryable();
        }

        public void Update(Album albums)
        {
            var albumUpdate = Get(albums.Id);
            albumUpdate.AlbumName = albums.AlbumName;
            albumUpdate.Year = albums.Year;
            albumUpdate.Musics = albums.Musics;
            albumUpdate.Band = albums.Band;
            albumUpdate.Genre = albums.Genre;
            _musicDb.SaveChanges();
        }
    }
}

