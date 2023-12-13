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
        IMusicLogic musicLogic;
        IAlbumLogic albumLogic;
        IBandLogic bandLogic;
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
        [HttpGet("{startDate}&{endDate}")]
        public IEnumerable<Album> BandBetweenDates(int startDate, int endDate)
        {
            return albumLogic.BandBetweenDates(startDate, endDate);
        }
        [HttpGet]
        public IEnumerable<Album> BandMoreThan1Album()
        {
            return albumLogic.BandMoreThan1Album();
        }
        [HttpGet]
        public IEnumerable<Album> DarkShadowsAlbumbs()
        {
            return albumLogic.DarkShadowsAlbumbs();
        }
        [HttpGet]
        public IEnumerable<Music> MusicWhereAlbumID2()
        {
            return musicLogic.MusicWhereAlbumID2();
        }
        [HttpGet]
        public IEnumerable<Music> MusicWhereAlbumAfter1991()
        {
            return musicLogic.MusicWhereAlbumAfter1991();
        }
        [HttpGet]
        public IEnumerable<Music> MusicWhereAlbumGenrePop()
        {
            return musicLogic.MusicWhereAlbumGenrePop();
        }

    }
}
