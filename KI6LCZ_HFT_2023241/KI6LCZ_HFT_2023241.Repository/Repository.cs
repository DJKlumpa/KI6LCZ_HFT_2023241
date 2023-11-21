using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KI6LCZ_HFT_2023241.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected MusicDbContext musicDb;

        public Repository(MusicDbContext musicDb)
        {
            this.musicDb = musicDb;
        }

        public abstract void Create(T t);


        public abstract void Delete(int id);


        public abstract T Get(int id);


        public IQueryable<T> ReadAll()
        {
            return musicDb.Set<T>();
        }

        public abstract void Update(T t);

    }
}
