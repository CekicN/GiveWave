using System.ComponentModel.DataAnnotations;

namespace GiveWaveAPI.Models
{
    public class Donacija
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TipDonacije { get; set; }
        [Required]
        public DateTime DatumDonacije { get; set; }

        public ProfilKorisnika ProfilKorisnika { get; set; }

    }
}
