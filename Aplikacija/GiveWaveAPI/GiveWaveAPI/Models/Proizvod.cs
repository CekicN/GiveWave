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

        public ProfilKorisnika ProfilKorisnika { get; set; }
        public Kategorija Kategorija { get; set; }
    }
}
