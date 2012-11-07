using System.Collections.Generic;
using GuitarWeb.Models;

namespace GuitarWeb.Interfaces
{
    public interface IAmplifierRepository
    {
        List<Amplifier> GetAmplifiers();
        void SaveAmplifiers(List<Amplifier> amplifiers);
        Amplifier GeAmplifierById(string regNumber);
    }
}
