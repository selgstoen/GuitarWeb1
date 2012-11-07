using System;

namespace GuitarWeb.Models
{
    [Serializable]
    public class Amplifier
    {
        public string RegNumber { get; set; }
        public string Manefacturer { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
    }
}