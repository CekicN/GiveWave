﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace GiveWaveAPI.Models
{
    public partial class Obuca
    {
        public string Id { get; set; }
        public Kategorija Kategorije { get; set; }
        [MaxLength(30)]
        public string Stanje { get; set; }
        [MaxLength(2)]
        public int Velicina { get; set; }
        [MaxLength(30)]
        public string Namena { get; set; }
        public string Opis { get; set; }
    }
}
