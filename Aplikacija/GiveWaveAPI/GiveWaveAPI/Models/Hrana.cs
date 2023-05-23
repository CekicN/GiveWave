using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace GiveWaveAPI.Models
{
    public class Hrana
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public DateTime DatumIsteka { get; set; }
        public string Opis { get; set; }
        [JsonIgnore]
        public Kategorija kategorija { get; set; }

    }
}
