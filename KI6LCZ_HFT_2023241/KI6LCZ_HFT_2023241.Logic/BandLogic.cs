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
        IBandRepository bandRepository;

        public BandLogic(IBandRepository bandRepository)
        {
            this.bandRepository = bandRepository;
        }

        public void Create(Band t)
        {
            bandRepository.Create(t);
        }

        public void Delete(int id)
        {
            bandRepository.Delete(id);
        }

        public Band Get(int id)
        {
            return bandRepository.Get(id);
        }

        public IQueryable<Band> GetAll()
        {
            return bandRepository.ReadAll();
        }

        public void Update(Band t)
        {
            bandRepository.Update(t);
        }

    }
}
