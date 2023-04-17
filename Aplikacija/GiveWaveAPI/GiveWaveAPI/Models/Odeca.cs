using System;
using System.Collections.Generic;

namespace GiveWaveAPI.Models
{
    public partial class Odeca
    {
        public int ID { get; set; }
        public int IDKategorije { get; set; }
        public string VrstaOdece { get; set; }
        public string Stanje { get; set; }
        public string Velicina { get; set; }
        public string Namena { get; set; }
        public int Uzrast { get; set; }
        public string Opis { get; set; }
    }
}
