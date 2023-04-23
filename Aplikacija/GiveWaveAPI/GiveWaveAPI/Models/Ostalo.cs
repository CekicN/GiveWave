using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace GiveWaveAPI.Models
{
    public partial class Ostalo
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Kozmetika { get; set; }

        [MaxLength(100)]
        public string HigijenskiProizvodi { get; set; }

        [MaxLength(100)]
        public string Elektronika { get; set; }

        [MaxLength(100)]
        public string Knjige { get; set; }

        [MaxLength(100)]
        public string Namestaj { get; set; }

        [MaxLength(100)]
        public string Alat { get; set; }

        [MaxLength(100)]
        public string MuzickiInstrumenti { get; set; }

        [MaxLength(100)]
        public string SportskaOprema { get; set; }

        [MaxLength(100)]
        public string KucniLjubimac { get; set; }

        [MaxLength(100)]
        public string Lekovi { get; set; }

        [MaxLength(100)]
        public string KucniAparati { get; set; }

        [MaxLength(100)]
        public string Vozila { get; set; }

        [MaxLength(100)]
        public string ZdravstvenaOprema { get; set; }

        public Kategorija Kategorije { get; set; }
    }
}
