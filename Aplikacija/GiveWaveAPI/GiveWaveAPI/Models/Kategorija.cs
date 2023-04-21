using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GiveWaveAPI.Models
{
    public partial class Kategorija
    {
        [Key]
        public string ID { get; set; }
        public string Ime { get; set; }
    }
}
