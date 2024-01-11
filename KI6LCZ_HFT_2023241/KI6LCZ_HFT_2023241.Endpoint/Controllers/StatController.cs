using KI6LCZ_HFT_2023241.Logic;
using KI6LCZ_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KI6LCZ_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IBandLogic bandLogic;
        IAlbumLogic albumLogic;
        IMusicLogic musicLogic;
        public StatController(IBandLogic bandLogic, IAlbumLogic albumLogic, IMusicLogic musicLogic)
        {
            this.bandLogic = bandLogic;
            this.albumLogic = albumLogic;
            this.musicLogic = musicLogic;
        }

        //https://localhost:54376/stat/BandID2Albums
        [HttpGet("{bandID}")]
        public IEnumerable<Album> BandID2Albums(int bandID)
        {
            return albumLogic.SpecificBandAlbums(bandID);
        }
        [HttpGet("{startDate}/{endDate}")]
        public IEnumerable<Album> AlbumBetweenDates(int startDate, int endDate)
        {
            return albumLogic.AlbumBetweenDates(startDate, endDate);
        }
        [HttpGet("{n}")]
        public IEnumerable<Band> BandMoreThanNAlbum(int n)
        {
            return bandLogic.BandMoreThanNAlbum(n);
        }
        [HttpGet("bandName")]
        public IEnumerable<Album> GetAlbumsWithBandName(string bandName)
        {
            return albumLogic.GetAlbumsWithBandName(bandName);
        }
        [HttpGet("{genre}")]
        public IEnumerable<Music> MusicWithGenre(Genre genre)
        {
            return musicLogic.MusicWithGenre(genre);
        }

    }
}
