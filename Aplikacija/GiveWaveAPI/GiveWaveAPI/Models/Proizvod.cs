using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GiveWaveAPI.Models
{
    public class Proizvod
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public byte[] Slika { get; set; }

        [Required]
        [MaxLength(20)]
        public string Naziv {get; set; }

        [MaxLength(255)]
        public string Opis {get; set; }

        [JsonIgnore]
        public ProfilKorisnika ProfilKorisnika { get; set; }
        [JsonIgnore]
        public Kategorije Kategorije { get; set; }

       
    }
}
