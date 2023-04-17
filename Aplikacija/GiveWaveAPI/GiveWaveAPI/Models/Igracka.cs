using System;
using System.Collections.Generic;

namespace GiveWaveAPI.Models
{
    public partial class Igracka
    {
        public int ID { get; set; }
        public int IDKategorije { get; set; }
        public string Vrsta { get; set; }
        public string Stanje { get; set; }
        public string Opis { get; set; }
    }
}
