using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GiveWaveAPI.Models
{
    public class Hrana
    {
        [Key]
        public string Id { get; set; }
        public Kategorija Kategorija { get; set; }

        [MaxLength(50)]
        public string Vrsta { get; set; }
        public DateTime DatumIsteka { get; set; }
        public string Opis { get; set; }
    }
}
