using System.ComponentModel.DataAnnotations;

namespace GiveWaveAPI.Models
{
    public class Message
    {
        [Required]
        public string From { get; set; }
        public string To { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
