using System;
using System.Collections.Generic;

namespace GiveWaveAPI.Models
{
    public partial class Ostalo
    {
        public int ID { get; set; }
        public int IDKategorije { get; set; }
        public string Kozmetika { get; set; }
        public string HigijenskiProizvodi { get; set; }
        public string Elektronika { get; set; }
        public string Knjige { get; set; }
        public string Namestaj { get; set; }
        public string Alat { get; set; }
        public string MuzickiInstrumenti { get; set; }
        public string SportskaOprema { get; set; }
        public string KucniLjubimac { get; set; }
        public string Lekovi { get; set; }
        public string KucniAparati { get; set; }
        public string Vozila { get; set; }
        public string ZdravstvenaOprema { get; set; }
    }
}
