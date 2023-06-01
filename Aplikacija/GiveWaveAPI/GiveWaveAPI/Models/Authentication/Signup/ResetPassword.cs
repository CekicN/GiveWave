using System.ComponentModel.DataAnnotations;

namespace GiveWaveAPI.Models.Authentication.Signup
{
    public class ResetPassword
    {
        [Required]
        public string newPassword { get; set; } = null!;
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string confirmPassword { get; set; } = null!;
        public string email { get; set; } = null!;
        public string token { get; set; } = null!;
    }
}
