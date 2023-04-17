using System;
using System.Collections.Generic;

namespace GiveWaveAPI.Models
{
    public partial class Obuca
    {
        public int ID { get; set; }
        public int IDKategorije { get; set; }
        public string Stanje { get; set; }
        public int Velicina { get; set; }
        public string Namena { get; set; }
        public string Opis { get; set; }
    }
}
