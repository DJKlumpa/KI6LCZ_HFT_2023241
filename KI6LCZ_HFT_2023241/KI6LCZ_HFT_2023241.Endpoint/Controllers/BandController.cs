using KI6LCZ_HFT_2023241.Endpoint.Services;
using KI6LCZ_HFT_2023241.Logic;
using KI6LCZ_HFT_2023241.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace KI6LCZ_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BandController : Controller
    {

        BandLogic logic;
        IHubContext<SignalRHub> rHub;

        public BandController(BandLogic logic, IHubContext<SignalRHub> rHub)
        {
            this.logic = logic;
            this.rHub = rHub;
        }

        //Get Band
        [HttpGet]
        public IEnumerable<Band> GetAll()
        {
            return this.logic.GetAll();
        }

        //Get Band/id
        [HttpGet("{id}")]
        public Band Get(int id)
        {
            return this.logic.Get(id);
        }

        //Create Band
        [HttpPost]
        public void Create([FromBody] Band value)
        {
            logic.Create(value);
            rHub.Clients.All.SendAsync("Band Created", value);
        }

        //Update Band
        [HttpPut]
        public void Update([FromBody] Band value)
        {
            logic.Update(value);
            rHub.Clients.All.SendAsync("Band Updated", value);
        }

        //Delete Band/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var temp = logic.Get(id);
            logic.Delete(id);
            rHub.Clients.All.SendAsync("Band Deleted", temp);
        }
    }
}
