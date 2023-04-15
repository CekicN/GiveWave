using System;
using System.Collections.Generic;

namespace GiveWaveAPI.Models
{
    public partial class Tehnika
    {
        public int ID { get; set; }
        public int IDKategorije { get; set; }
        public string Vrsta { get; set; }
        public string Stanje { get; set; }
        public int GodinaProizvodnje { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Specifikacije { get; set; }

    }
}
