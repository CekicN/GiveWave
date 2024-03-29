﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace GiveWaveAPI.Models
{
    public partial class Tehnika
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Vrsta { get; set; }

        [MaxLength(100)]
        public string Stanje { get; set; }

        [MaxLength(4)]
        public int GodinaProizvodnje { get; set; }

        [MaxLength(50)]
        public string Marka { get; set; }

        [MaxLength(50)]
        public string Model { get; set; }

        [MaxLength(100)]
        public string Specifikacije { get; set; }
        [JsonIgnore]
        public Kategorija kategorija { get; set; }



    }
}
