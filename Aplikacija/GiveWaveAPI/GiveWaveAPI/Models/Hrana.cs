using System;
using System.Collections.Generic;

namespace GiveWaveAPI.Models
{
    public partial class Hrana
    {
        public int ID { get; set; }
        public int IDKategorije { get; set; }
        public string Vrsta { get; set; }
        public DateTime DatumIsteka { get; set; }
        public string Opis { get; set; }
    }
}
