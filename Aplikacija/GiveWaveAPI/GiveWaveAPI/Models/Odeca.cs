using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GiveWaveAPI.Models
{
    public partial class Odeca
    {
        [Key]
        public string Id { get; set; }
        public Kategorija Kategorije { get; set; }
        [MaxLength(50)]
        public string VrstaOdece { get; set; }
        [MaxLength(50)]
        public string Stanje { get; set; }
        [MaxLength(20)]
        public string Velicina { get; set; }
        [MaxLength(50)]
        public string Namena { get; set; }
        [Range(0,100)]
        public int Uzrast { get; set; }
        [MaxLength(100)]
        public string Opis { get; set; }
    }
}
