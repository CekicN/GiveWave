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
        public Kategorija Kategorija { get; set; }
    }
}
