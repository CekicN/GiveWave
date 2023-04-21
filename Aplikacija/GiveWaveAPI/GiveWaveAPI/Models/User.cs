using Microsoft.AspNetCore.Identity;

namespace GiveWaveAPI.Models;

public partial class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
