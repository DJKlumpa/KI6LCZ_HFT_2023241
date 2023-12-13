using KI6LCZ_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KI6LCZ_HFT_2023241.Repository
{
    public class MusicRepository : IMusicRepository
    {
        public MusicDbContext musicDb;
        public MusicRepository(MusicDbContext musicDb)
        {
            this.musicDb = musicDb;
        }

        public void Create(Music item)
        {
            musicDb.Musics.Add(item);
            musicDb.SaveChanges();
        }

        public void Delete(int id)
        {
            Music toDelete = Get(id);
            musicDb.Remove(toDelete);
            musicDb.SaveChanges();
        }

        public Music Get(int id)
        {
            return musicDb.Musics.SingleOrDefault(X => X.Id == id);
        }

        public IQueryable<Music> ReadAll()
        {
            return musicDb.Musics.AsQueryable();
        }

        public void Update(Music musics)
        {
            var musicUpdate = Get(musics.Id);
            musicUpdate.Title = musics.Title;
            musicUpdate.Album = musics.Album;
            musicUpdate.Genre = musics.Genre;
            musicUpdate.Length = musics.Length;
            musicDb.SaveChanges();
        }
    }
}
