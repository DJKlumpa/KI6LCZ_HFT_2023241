using KI6LCZ_HFT_2023241.Logic;
using KI6LCZ_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KI6LCZ_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BandController : ControllerBase
    {
        IBandLogic logic;

        public BandController(IBandLogic logic)
        {
            this.logic = logic;
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
        }

        //Update Band
        [HttpPut]
        public void Update([FromBody] Band value)
        {
            logic.Update(value);
        }

        //Delete Band/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var temp = logic.Get(id);
            logic.Delete(id);
        }
    }
}
