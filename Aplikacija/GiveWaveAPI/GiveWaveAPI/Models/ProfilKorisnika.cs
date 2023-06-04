using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GiveWaveAPI.Models
{
    public partial class ProfilKorisnika
    {
        

        [Key]
        public int Id { get; set; }

        //[MaxLength(50)]
        //public string Ime { get; set; }

        //[MaxLength(50)]
        //public string Prezime { get; set; }

        [MaxLength(50)]
        public string Username { get; set; }

        [MaxLength(50)]
        [RegularExpression("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$")]
        public string Email { get; set; }

        [RegularExpression("^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$")]
        public string BrojTelefona { get; set; }

        [MaxLength(100)]
        public string Adresa { get; set; }
        public DateTime DatumRodjenja { get; set; }

        [MaxLength(10)]
        public string Pol { get; set; }

        [MaxLength(50)]
        public string StatusAktivnosti { get; set; }
        public int BrojLajkova { get; set; }
        public String ImageUrl { get; set; }
        public DateTime DatumRegistracije { get; set; }
        [JsonIgnore]
        public List<Proizvod> Proizvodi { get; set; }
       // public List<User> Useri { get; set; }
        public List<Donacija> Donacije { get; set; }
       



    }
}
