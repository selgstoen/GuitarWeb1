using System.Collections.Generic;
using GuitarWeb.Models;

namespace GuitarWeb.Interfaces
{
    public interface IGuitarRepository
    {
        List<Guitar> GetGuitars();
        void SaveGuitars(List<Guitar> guitars);
        Guitar GetGuitarById(string regNumber);
    }
}
