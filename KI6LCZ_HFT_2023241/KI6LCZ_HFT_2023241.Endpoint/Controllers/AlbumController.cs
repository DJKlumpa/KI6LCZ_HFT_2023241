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
        public class AlbumController : ControllerBase
        {

            AlbumLogic logic;
            IHubContext<SignalRHub> rHub;


            public AlbumController(AlbumLogic logic, IHubContext<SignalRHub> rHub)
            {
                this.logic = logic;
                this.rHub = rHub;
            }

            //Get Album
            [HttpGet]
            public IEnumerable<Album> GetAll()
            {
                return this.logic.GetAll();
            }

            //Get Album/id
            [HttpGet("{id}")]
            public Album Get(int id)
            {
                return this.logic.Get(id);
            }

            //Create Album
            [HttpPost]
            public void Create([FromBody] Album value)
            {
                logic.Create(value);
                rHub.Clients.All.SendAsync("Album Created", value);
            }

            //Update Album
            [HttpPut]
            public void Update([FromBody] Album value)
            {
                logic.Update(value);
                rHub.Clients.All.SendAsync("Album Updated", value);
            }

            //Delete Album/id
            [HttpDelete("{id}")]
            public void Delete(int id)
            {
                var temp = logic.Get(id);
                logic.Delete(id);
                rHub.Clients.All.SendAsync("Album Deleted", temp);
            }
        }
    }
