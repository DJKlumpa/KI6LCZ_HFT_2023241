using KI6LCZ_HFT_2023241.Models;
using KI6LCZ_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KI6LCZ_HFT_2023241.Logic
{
    public class AlbumLogic : ILogic<Album>
    {
        private IRepository<Album> _repository;

        public AlbumLogic(IRepository<Album> repository)
        {
            _repository = repository;
        }

        public void Create(Album t)
        {
            _repository.Create(t);
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }

        public Album Get(string id)
        {
            return _repository.Get(id);
        }

        public IQueryable<Album> GetAll()
        {
            return _repository.ReadAll();
        }

        public void Update(Album t)
        {
            _repository.Update(t);
        }
    }
}
