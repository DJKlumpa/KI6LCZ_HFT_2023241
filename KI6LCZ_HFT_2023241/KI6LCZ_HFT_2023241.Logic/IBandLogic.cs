using KI6LCZ_HFT_2023241.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KI6LCZ_HFT_2023241.Logic
{
    public interface IBandLogic : ILogic<Band>
    {
        IEnumerable<Band> BandMoreThanNAlbum(int n);
    }
}