using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GiveWaveAPI.Models
{
    public partial class Igracka
    {
        [Key]
        public string Id { get; set; }
        public Kategorija Kategorije { get; set; }
        [MaxLength(50)]
        public string Vrsta { get; set; }
        public string Stanje { get; set; }
        public string Opis { get; set; }
        
    }
}
