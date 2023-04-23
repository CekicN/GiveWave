using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace GiveWaveAPI.Models
{
    public partial class Novac
    {
        [Key]
        public string Id { get; set; }
        public int BrojTransakcije { get; set; }
        public Kategorija Kategorije { get; set; }
        public int Iznos { get; set; }
        [MaxLength(100)]
        public string IzvorNovca { get; set; }
        public DateTime DatumDonacije { get; set; }
    }
}
