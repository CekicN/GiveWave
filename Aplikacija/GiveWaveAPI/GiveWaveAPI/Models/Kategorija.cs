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
<<<<<<< HEAD
        public string Name { get; set; }
        [JsonIgnore]
        [ForeignKey("parentID")]
        public Kategorija parentCategory { get; set; }
        public List<Kategorija> Subcategories { get; set; }
=======
        public string naziv { get; set; }
        public List<Hrana> Hrana { get; set; }
        public List<Igracka> Igracka { get; set;}
        public List<Krv> Krv { get; set;}
        public List<Novac> Novac { get; set; }
        public List<Obuca> Obuca { get; set; }
        public List<Odeca> Odeca { get; set; }
        public List<Tehnika> Tehnika { get; set;}
        public List<Porodica> Porodica { get; set; }
        public List<Proizvod> Proizvod { get; set; }
        public List<Ostalo> Ostalo { get; set; }


>>>>>>> 0d8691bd635323b851da06e62a2ec127e738eef1
    }
}
