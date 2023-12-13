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

        [HttpGet]
        public IEnumerable<Album> q1()
        {
            return albumLogic.BandID2Albums();
        }
        [HttpGet]
        public IEnumerable<Album> q2()
        {
            return albumLogic.BandBetween91and2009();
        }
        [HttpGet]
        public IEnumerable<Album> q3()
        {
            return albumLogic.BandMoreThan1Album();
        }
        [HttpGet]
        public IEnumerable<Album> q4()
        {
            return albumLogic.DarkShadowsAlbumbs();
        }
        [HttpGet]
        public IEnumerable<Music> q5()
        {
            return musicLogic.MusicWhereAlbumID2();
        }
        [HttpGet]
        public IEnumerable<Music> q6()
        {
            return musicLogic.MusicWhereAlbumAfter1991();
        }
        [HttpGet]
        public IEnumerable<Music> q7()
        {
            return musicLogic.MusicWhereAlbumGenrePop();
        }

    }
}
