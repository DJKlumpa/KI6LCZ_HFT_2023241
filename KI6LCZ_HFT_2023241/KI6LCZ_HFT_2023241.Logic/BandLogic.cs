using KI6LCZ_HFT_2023241.Models;
using KI6LCZ_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KI6LCZ_HFT_2023241.Logic
{
    public class BandLogic : IBandLogic
    {
        private readonly IRepository<Band> _bandRepository;

        public BandLogic(IRepository<Band> bandRepository)
        {
            this._bandRepository = bandRepository;
        }

        public void Create(Band t)
        {
            if (string.IsNullOrEmpty(t.BandName))
            {
                throw new Exception("Name is empty");
            }

            _bandRepository.Create(t);
        }

        public void Delete(int id)
        {
            _bandRepository.Delete(id);
        }

        public Band Get(int id)
        {
            return _bandRepository.Get(id);
        }

        public IQueryable<Band> GetAll()
        {
            return _bandRepository.ReadAll();
        }

        public void Update(Band t)
        {
            _bandRepository.Update(t);
        }

    }
}
