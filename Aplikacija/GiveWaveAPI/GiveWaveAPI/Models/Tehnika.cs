using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GiveWaveAPI.Models
{
    public partial class Tehnika
    {
        public string Id { get; set; }
        public Kategorija Kategorije { get; set; }
        [MaxLength(50)]
        public string Vrsta { get; set; }
        [MaxLength(100)]
        public string Stanje { get; set; }
        [MaxLength(4)]
        public int GodinaProizvodnje { get; set; }
        [MaxLength(50)]
        public string Marka { get; set; }
        [MaxLength(50)]
        public string Model { get; set; }
        [MaxLength(50)]
        public string Specifikacije { get; set; }
    }
}
