using System;
using System.Collections.Generic;

namespace GiveWaveAPI.Models
{
    public partial class Krv
    {
        public int ID { get; set; }
        public int IDKategorije { get; set; }
        public string KrvnaGrupa { get; set; }
        public DateTime DatumDoniranja { get; set; }
        public double KolicinaDoniraneKrvi { get; set; }
        public string LokacijaDoniranja { get; set; }
    }
}
