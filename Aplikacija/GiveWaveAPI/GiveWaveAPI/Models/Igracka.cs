using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GiveWaveAPI.Models
{
    public partial class Igracka
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Vrsta { get; set; }
        public string Stanje { get; set; }
        public string Opis { get; set; }

        public Kategorija Kategorije { get; set; }
    }
}
