using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GiveWaveAPI.Models
{
    public partial class Obuca
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        public string Stanje { get; set; }
        [MaxLength(2)]
        public int Velicina { get; set; }
        [MaxLength(30)]
        public string Namena { get; set; }
        public string Opis { get; set; }
        [JsonIgnore]
        public Kategorija kategorija { get; set; }
    }
}
