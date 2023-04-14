using System;
using System.Collections.Generic;

namespace GiveWaveAPI.Models
{
    public partial class ProfilKorisnika
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public int BrojTelefona { get; set; }
        public string Adresa { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Pol { get; set; }
        public string StatusAktivnosti { get; set; }
        public DateTime DatumRegistracije { get; set; }
    }
}
