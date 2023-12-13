using KI6LCZ_HFT_2023241.Logic;
using KI6LCZ_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KI6LCZ_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumLogic _albumLogic;

        public AlbumController(IAlbumLogic albumLogic)
        {
            this._albumLogic = albumLogic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_albumLogic.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_albumLogic.Get(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Album album)
        {
            try
            {
                _albumLogic.Create(album);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public void Put([FromBody] Album album)
        {
            _albumLogic.Update(album);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Album albumToDelete = _albumLogic.Get(id);
            _albumLogic.Delete(id);
        }
    }
}
