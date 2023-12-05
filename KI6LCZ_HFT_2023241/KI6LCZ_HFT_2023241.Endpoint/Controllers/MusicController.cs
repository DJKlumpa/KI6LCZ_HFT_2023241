using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using KI6LCZ_HFT_2023241.Logic;
using KI6LCZ_HFT_2023241.Models;
using System.Collections.Generic;
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
        

        public MusicController(MusicLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<MusicController>
        [HttpGet]
        public IEnumerable<Music> GetAll()
        {
            return this.logic.GetAll();
        }

        
        [HttpGet("{id}")]
        public Music Get(int id)
        {
            return this.logic.Get(id);
        }

        
        [HttpPost]
        public void Create([FromBody] Music value)
        {
            this.logic.Create(value);
        }

        
        [HttpPut]
        public void Update([FromBody] Music value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
