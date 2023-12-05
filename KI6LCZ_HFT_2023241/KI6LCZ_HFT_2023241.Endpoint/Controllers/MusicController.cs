using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using KI6LCZ_HFT_2023241.Logic;
using KI6LCZ_HFT_2023241.Models;
using KI6LCZ_HFT_2023241.Endpoint.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KI6LCZ_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {

        MusicLogic logic;
        IHubContext<SignalRHub> rHub;
        

        public MusicController(MusicLogic logic, IHubContext<SignalRHub> rHub)
        {
            this.logic = logic;
            this.rHub = rHub;
        }

        //Get Music
        [HttpGet]
        public IEnumerable<Music> GetAll()
        {
            return this.logic.GetAll();
        }

        //Get Music/id
        [HttpGet("{id}")]
        public Music Get(int id)
        {
            return this.logic.Get(id);
        }

        //Create Music
        [HttpPost]
        public void Create([FromBody] Music value)
        {
            logic.Create(value);
            rHub.Clients.All.SendAsync("Music Created", value);
        }

        //Update Music
        [HttpPut]
        public void Update([FromBody] Music value)
        {
            logic.Update(value);
            rHub.Clients.All.SendAsync("Music Updated", value);
        }

        //Delete Music/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var temp = logic.Get(id);
            logic.Delete(id);
            rHub.Clients.All.SendAsync("Music Deleted", temp);
        }
    }
}
