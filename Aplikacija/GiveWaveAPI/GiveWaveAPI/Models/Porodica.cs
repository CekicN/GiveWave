using System.ComponentModel.DataAnnotations;

namespace GiveWaveAPI.Models
{
    public class Porodica
    {
        [Key]
        public int Id { get; set; }

        public string ImageUrls { get; set; }

        public int BrClanova { get; set; }
        public string Grad { get; set; }

        [MaxLength(50)]
        public string Adresa { get; set; }

        //[MaxLength(255)]
        //public List<string> NajpotrebnijeStvari { get; set; }

        [MaxLength(255)]
        public string Opis { get; set; }
        public string Status { get; set; }

    }
}
