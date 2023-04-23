using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace GiveWaveAPI.Models
{
    public partial class Kategorija
    {
        [Key]
        public int Id { get; set; }
        public string Ime { get; set; }


    }
}
