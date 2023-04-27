using GiveWaveAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace GiveWaveAPI.Controllers
{
    [ApiController]
    [Route("controller")]
    public class ProfileController : Controller
    {
        public GiveWaveDBContext Context;
        public ProfileController(GiveWaveDBContext context)
        {
            Context = context;
        }

        [Route("PreuzmiProfil")]
        [HttpPost, Authorize]
        public async Task<ActionResult> PreuzmiProfil([FromBody] String email)
        {
            try
            {
                var profil = Context.ProfilKorisnikas.Where(korisnik => korisnik.Email == email).FirstOrDefault();
                if(profil == null)
                {
                    return BadRequest("profil nije pronajden");
                }
                return Ok(profil);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Route("setPhoto/{id}")]
        [HttpPost, Authorize]
        public async Task<ActionResult> SetPhoto(int id, IFormFile file)
        {
            try
            {
                var user = Context.ProfilKorisnikas.Where(User => User.Id == id).FirstOrDefault();
                if(user == null)
                {
                    return BadRequest("Korisnik nije pronadjen");
                }

                using(var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    user.Image = memoryStream.ToArray();
                }

                Context.ProfilKorisnikas.Update(user);
                await Context.SaveChangesAsync();
                return Ok("Dodata je slika");

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
