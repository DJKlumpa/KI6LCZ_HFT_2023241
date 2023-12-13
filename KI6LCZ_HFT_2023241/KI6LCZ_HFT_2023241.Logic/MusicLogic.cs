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
        IMusicRepository musicRepository;
        public MusicLogic(IMusicRepository musicRepository)
        {
            this.musicRepository = musicRepository;
        }

        public Music Get(int id)
        {
            return musicRepository.Get(id);
        }
        public IQueryable<Music> GetAll()
        {
            return musicRepository.ReadAll();
        }

        public void Create(Music t)
        {
            musicRepository.Create(t);
        }

        public void Delete(int id)
        {
            musicRepository.Delete(id);
        }
        public void Update(Music t)
        {
            musicRepository.Update(t);
        }
        public IEnumerable<Music> MusicWhereAlbumID2()
        {
            var musicForBand = musicRepository.ReadAll().Where(music => music.Album.BandId == 2).ToList();
            return musicForBand;
        }
        public IEnumerable<Music> MusicWhereAlbumAfter1991()
        {
            var musicAfter1991 = musicRepository.ReadAll().Where(music => music.Album.Year > 1991).ToList();
            return musicAfter1991;
        }
        public IEnumerable<Music> MusicWhereAlbumGenrePop()
        {
            var musicAlbumPop = musicRepository.ReadAll().Where(music => music.Album.Genre == "Pop").ToList();
            return musicAlbumPop;
        }
    }
}
