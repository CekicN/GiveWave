using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GiveWaveAPI.Models
{
    public partial class Kategorija
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        [ForeignKey("parentID")]
        public Kategorija parentCategory { get; set; }
        public List<Kategorija> Subcategories { get; set; }
        [JsonIgnore]
        public List<Proizvod> Proizvodi { get; set; }
    }
}
