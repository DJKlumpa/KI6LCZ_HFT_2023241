using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using KI6LCZ_HFT_2023241.Logic;
using KI6LCZ_HFT_2023241.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KI6LCZ_HFT_2023241.Endpoint.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicLogic _musicLogic;

        public MusicController(IMusicLogic musicLogic)
        {
            this._musicLogic = musicLogic;
        }

        //Get Music
        [HttpGet]
        public IEnumerable<Music> GetAll()
        {
            return this._musicLogic.GetAll();
        }

        //Get Music/id
        [HttpGet("{id}")]
        public Music Get(int id)
        {
            return this._musicLogic.Get(id);
        }

        //Create Music
        [HttpPost]
        public void Create([FromBody] Music value)
        {
            _musicLogic.Create(value);
        }

        //Update Music
        [HttpPut]
        public void Update([FromBody] Music value)
        {
            _musicLogic.Update(value);
        }

        //Delete Music/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var temp = _musicLogic.Get(id);
            _musicLogic.Delete(id);
        }
    }
}
