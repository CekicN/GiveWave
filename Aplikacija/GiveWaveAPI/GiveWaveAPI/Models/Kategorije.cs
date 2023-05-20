using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace GiveWaveAPI.Models
{
    public partial class Kategorije
    {
        [Key]
        public int Id { get; set; }
        public List<Kategorija> Kategorija { get; set; }
    }
}
