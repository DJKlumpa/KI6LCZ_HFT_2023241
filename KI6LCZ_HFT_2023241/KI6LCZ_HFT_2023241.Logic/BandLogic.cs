using KI6LCZ_HFT_2023241.Models;
using KI6LCZ_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KI6LCZ_HFT_2023241.Logic
{
    public class BandLogic:ILogic<Band>
    {
        private IRepository<Band> _repository;

        public BandLogic(IRepository<Band> repository)
        {
            _repository = repository;
        }

        public void Create(Band t)
        {
            _repository.Create(t);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Band Get(int id)
        {
            return _repository.Get(id);
        }

        public IQueryable<Band> GetAll()
        {
            return _repository.ReadAll();
        }

        public void Update(Band t)
        {
            _repository.Update(t);
        }
    }
}
