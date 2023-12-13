using System;
using KI6LCZ_HFT_2023241.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KI6LCZ_HFT_2023241.Repository;

namespace KI6LCZ_HFT_2023241.Logic
{
    public class MusicLogic : IMusicLogic
    {
        private readonly IRepository<Music> _musicRepository;
        public MusicLogic(IRepository<Music> musicRepository)
        {
            this._musicRepository = musicRepository;
        }

        public Music Get(int id)
        {
            return _musicRepository.Get(id);
        }
        public IQueryable<Music> GetAll()
        {
            return _musicRepository.ReadAll();
        }

        public void Create(Music t)
        {
            if (string.IsNullOrEmpty(t.Title))
            {
                throw new Exception("Title is empty");
            }

            _musicRepository.Create(t);
        }

        public void Delete(int id)
        {
            _musicRepository.Delete(id);
        }
        public void Update(Music t)
        {
            _musicRepository.Update(t);
        }
        public IEnumerable<Music> MusicWhereAlbumID2()
        {
            var musicForBand = _musicRepository.ReadAll().Where(music => music.Album.BandId == 2).ToList();
            return musicForBand;
        }
        public IEnumerable<Music> MusicWhereAlbumAfter1991()
        {
            var musicAfter1991 = _musicRepository.ReadAll().Where(music => music.Album.Year > 1991).ToList();
            return musicAfter1991;
        }
        public IEnumerable<Music> MusicWhereAlbumGenrePop()
        {
            var musicAlbumPop = _musicRepository.ReadAll().Where(music => music.Album.Genre == "Pop").ToList();
            return musicAlbumPop;
        }
    }
}
