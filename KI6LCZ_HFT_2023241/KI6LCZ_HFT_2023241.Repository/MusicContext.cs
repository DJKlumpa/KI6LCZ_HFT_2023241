using KI6LCZ_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace KI6LCZ_HFT_2023241.Repository
{
    public interface IMusicRepository
    {
        void Create(Music music);
        Music Listen(int id);
        IQueryable<Music> ReadAll();
        void Update (Music music);
        void Delete(int id);
    }
    public class MusicDbContext : DbContext
    {
    }
}
