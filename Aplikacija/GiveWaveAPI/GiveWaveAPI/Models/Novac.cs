using System;
using System.Collections.Generic;

namespace GiveWaveAPI.Models
{
    public partial class Novac
    {
        public int BrojTransakcije { get; set; }
        public int IDKategorije { get; set; }
        public int Iznos { get; set; }
        public string IzvorNovca { get; set; }
        public DateTime DatumDonacije { get; set; }
    }
}
