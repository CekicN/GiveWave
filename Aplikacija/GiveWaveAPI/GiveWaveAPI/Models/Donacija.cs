using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace GiveWaveAPI.Models
{
    public class Donacija
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string donacija { get; set; }
        [Required]
        public DateTime DatumDonacije { get; set; }
        [MaxLength(1000)]
        public string Opis { get; set; }
        [JsonIgnore]
        public ProfilKorisnika ProfilKorisnika { get; set; }
        [JsonIgnore]
        public Porodica Porodica { get; set; }
    }
}
