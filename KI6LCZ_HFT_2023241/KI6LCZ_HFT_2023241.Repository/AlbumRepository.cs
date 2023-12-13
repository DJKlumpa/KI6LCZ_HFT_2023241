using KI6LCZ_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KI6LCZ_HFT_2023241.Repository
{
    public class AlbumRepository : IAlbumRepository
    {
        public MusicDbContext musicDb;
        public AlbumRepository(MusicDbContext musicDb)
        {
            this.musicDb = musicDb;
        }
        public void Create(Album item)
        {
            musicDb.Add(item);
            musicDb.SaveChanges();
        }

        public void Delete(int id)
        {
            Album toDelete = Get(id);
            musicDb.Remove(toDelete);
            musicDb.SaveChanges();
        }

        public Album Get(int id)
        {
            return musicDb.Albums.SingleOrDefault(X => X.Id == id);
        }

        public IQueryable<Album> ReadAll()
        {
            return musicDb.Albums.AsQueryable();
        }

        public void Update(Album albums)
        {
            var albumUpdate = Get(albums.Id);
            albumUpdate.AlbumName = albums.AlbumName;
            albumUpdate.Year = albums.Year;
            albumUpdate.Musics = albums.Musics;
            albumUpdate.Band = albums.Band;
            albumUpdate.Genre = albums.Genre;
            musicDb.SaveChanges();
        }
    }
}

