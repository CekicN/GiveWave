using GiveWaveAPI.Models;

namespace GiveWaveAPI.Helpers
{
    public class ProductHelper
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Mesto { get; set; }
        public string ImageUrl { get; set; }
        public Status status { get; set; }
        public string emailKorisnika{ get; set; }
        public string Kategorija { get; set; }
    }
}
