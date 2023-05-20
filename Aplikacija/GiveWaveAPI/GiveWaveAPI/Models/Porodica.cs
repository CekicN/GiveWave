using System.ComponentModel.DataAnnotations;

namespace GiveWaveAPI.Models
{
    public class Porodica
    {
        [Key]
        public int Id { get; set; }

        public byte[] Slika { get; set; }

        public int BrClanova { get; set; }

        [MaxLength(50)]
        public string Adresa { get; set; }

        [MaxLength(255)]
        public string NajpotrebnijeStvari { get; set; }

        [MaxLength(255)]
        public string Opis { get; set; }

        public List<Kategorije> Kategorije { get; set;}
        public List<Proizvod> Proizvodi { get; set; }





    }
}
