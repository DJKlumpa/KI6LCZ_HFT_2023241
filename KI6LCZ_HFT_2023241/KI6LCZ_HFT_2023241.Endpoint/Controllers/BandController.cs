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
        private readonly IBandLogic _bandLogic;

        public BandController(IBandLogic bandLogic)
        {
            this._bandLogic = bandLogic;
        }

        //Get Band
        [HttpGet]
        public IEnumerable<Band> GetAll()
        {
            return this._bandLogic.GetAll();
        }

        //Get Band/id
        [HttpGet("{id}")]
        public Band Get(int id)
        {
            return this._bandLogic.Get(id);
        }

        //Create Band
        [HttpPost]
        public void Create([FromBody] Band value)
        {
            _bandLogic.Create(value);
        }

        //Update Band
        [HttpPut]
        public void Update([FromBody] Band value)
        {
            _bandLogic.Update(value);
        }

        //Delete Band/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var temp = _bandLogic.Get(id);
            _bandLogic.Delete(id);
        }
    }
}
