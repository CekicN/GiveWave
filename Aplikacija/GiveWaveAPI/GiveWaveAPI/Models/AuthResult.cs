using System.Text.Json;
namespace GiveWaveAPI.Models
{
    public class AuthResult
    {
        public string Token { get; set; } = default!;
        public string RefreshToken { get; set; } = default!;
        public bool Result { get; set; }=default!;
        public List<string> Errors { get; set; } = default!;
    }
}
