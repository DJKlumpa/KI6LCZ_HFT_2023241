﻿using KI6LCZ_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KI6LCZ_HFT_2023241.Repository
{
    public class MusicRepository : IRepository<Music>
    {
        private readonly MusicDbContext _musicDb;
        public MusicRepository(MusicDbContext musicDb)
        {
            this._musicDb = musicDb;
        }

        public void Create(Music item)
        {
            _musicDb.Musics.Add(item);
            _musicDb.SaveChanges();
        }

        public void Delete(int id)
        {
            Music toDelete = Get(id);
            _musicDb.Remove(toDelete);
            _musicDb.SaveChanges();
        }

        public Music Get(int id)
        {
            return _musicDb.Musics.SingleOrDefault(X => X.Id == id);
        }

        public IQueryable<Music> ReadAll()
        {
            return _musicDb.Musics.AsQueryable();
        }

        public void Update(Music musics)
        {
            var musicUpdate = Get(musics.Id);
            musicUpdate.Title = musics.Title;
            musicUpdate.Album = musics.Album;
            musicUpdate.Genre = musics.Genre;
            musicUpdate.Length = musics.Length;
            _musicDb.SaveChanges();
        }
    }
}
