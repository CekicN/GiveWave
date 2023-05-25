using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace GiveWaveAPI.Models
{
    public partial class Krv
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(2)]
        public string KrvnaGrupa { get; set; }
        public DateTime DatumDoniranja { get; set; }
        public double KolicinaDoniraneKrvi { get; set; }
        public string LokacijaDoniranja { get; set; }
        [JsonIgnore]
        public Kategorija kategorija { get; set; }

    }
}
