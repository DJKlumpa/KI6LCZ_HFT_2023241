using KI6LCZ_HFT_2023241.Logic;
using KI6LCZ_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KI6LCZ_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        IAlbumLogic albumLogic;
        public AlbumController(IAlbumLogic albumLogic)
        {
            this.albumLogic = albumLogic;
        }

        [HttpGet]
        public IEnumerable<Album> Get()
        {
            return albumLogic.GetAll();
        }

        [HttpGet("{id}")]
        public Album Get(int id)
        {
            return albumLogic.Get(id);
        }

        [HttpPost]
        public void Post([FromBody] Album album)
        {
            albumLogic.Create(album);
        }

        [HttpPut]
        public void Put([FromBody] Album album)
        {
            albumLogic.Update(album);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var albumToDelete = albumLogic.Get(id);
            albumLogic.Delete(id);
        }
    }
}
