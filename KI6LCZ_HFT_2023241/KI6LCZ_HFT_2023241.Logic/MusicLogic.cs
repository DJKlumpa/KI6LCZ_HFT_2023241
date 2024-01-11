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
        private readonly IRepository<Album> _albumRepository;
        public MusicLogic(IRepository<Music> musicRepository, IRepository<Album> albumRepository)
        {
            this._musicRepository = musicRepository;
            _albumRepository = albumRepository;
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
        public IEnumerable<Music> MusicWithGenre(Genre genre)
        {
            var musicAlbumPop = _musicRepository.ReadAll().Where(x => x.Genre.Equals(genre)).ToList();

            return musicAlbumPop;
        }
    }
}
