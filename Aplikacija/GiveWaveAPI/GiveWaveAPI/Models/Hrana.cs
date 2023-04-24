using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace GiveWaveAPI.Models
{
    public class Hrana
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Vrsta { get; set; }
        public DateTime DatumIsteka { get; set; }
        public string Opis { get; set; }
        public Kategorija Kategorija { get; set; }
    }
}
