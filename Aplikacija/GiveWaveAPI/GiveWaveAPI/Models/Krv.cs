using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GiveWaveAPI.Models
{
    public partial class Krv
    {
        [Key]
        public string Id { get; set; }
        public Kategorija Kategorije { get; set; }
        [MaxLength(2)]
        public string KrvnaGrupa { get; set; }
        public DateTime DatumDoniranja { get; set; }
        public double KolicinaDoniraneKrvi { get; set; }
        public string LokacijaDoniranja { get; set; }
    }
}
