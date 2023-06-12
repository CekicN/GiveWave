using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace GiveWaveAPI.Models
{
    public class Porodica
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }

        public string UrlSlika { get; set; }
        [Required]
        public int BrClanova { get; set; }
        [Required]
        public string Grad { get; set; }
        [Required]
        [MaxLength(50)]
        public string Adresa { get; set; }
        [Required]
        [MaxLength(255)]
        public string najpotrebnijestvari { get; set; }
        [Required]
        [MaxLength(255)]
        public string Opis { get; set; }
        public string Status { get; set; }
        public string BrTelefona { get; set; }
        public string ZiroRacun { get; set; }
        public bool Potvrda { get; set; }
        public List<Donacija> Donacije { get; set; }
        public ProfilKorisnika ProfilKorisnika { get; set; }

    }
}
