using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GiveWaveAPI.Models
{
    public enum Status
    {
        New,
        SecondHand
    }

    public class Proizvod
    {
        [Key]
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(20)]
        public string Naziv {get; set; }
        public string Mesto { get; set; }
        public Status status { get; set; }
        [MaxLength(255)]
        public string Opis {get; set; }

        [JsonIgnore]
        public ProfilKorisnika ProfilKorisnika { get; set; }
        [JsonIgnore]
        public Kategorija Kategorije { get; set; }

       
    }
}
