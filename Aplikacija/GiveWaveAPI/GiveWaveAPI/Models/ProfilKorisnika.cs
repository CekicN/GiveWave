using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace GiveWaveAPI.Models
{
    public partial class ProfilKorisnika
    {
        public string Id { get; set; }
        [MaxLength(50)]
        public string Ime { get; set; }
        [MaxLength(50)]
        public string Prezime { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(50)]
        public int BrojTelefona { get; set; }
        [MaxLength(100)]
        public string Adresa { get; set; }

        public DateTime DatumRodjenja { get; set; }
        [MaxLength(10)]
        public string Pol { get; set; }
        [MaxLength(50)]
        public string StatusAktivnosti { get; set; }
        public int BrojLajkova { get; set; }
        public byte[] Image { get; set; }
        public DateTime DatumRegistracije { get; set; }
    }
}
