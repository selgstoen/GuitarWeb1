using System;

namespace GuitarWeb.Models
{
    [Serializable]
    public class Guitar
    {
        public string RegNumber { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
    }
}