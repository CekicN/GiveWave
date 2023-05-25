using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [JsonIgnore]
        public Kategorija kategorija { get; set; }
    }
}
