using System;
using KI6LCZ_HFT_2023241.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KI6LCZ_HFT_2023241.Repository;

namespace KI6LCZ_HFT_2023241.Logic
{
    public class MusicLogic : ILogic<Music>
    {
        private IRepository<Music> _repository;

        public MusicLogic(IRepository<Music> repository)
        {
            _repository = repository;
        }

        public void Create(Music t)
        {
            _repository.Create(t);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Music Get(int id)
        {
            return _repository.Get(id);
        }

        public IQueryable<Music> GetAll()
        {
            return _repository.ReadAll();
        }

        public void Update(Music t)
        {
            _repository.Update(t);
        }
    }
}
