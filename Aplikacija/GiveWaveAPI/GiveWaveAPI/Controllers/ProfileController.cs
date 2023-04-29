using GiveWaveAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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
        //MEtoda za kreiranje profila korisnika koja ce da uzme samo registraciju ostalo prazno
        [Route("PreuzmiProfil")]
        [HttpPost]
        public async Task<ActionResult> PreuzmiProfil([FromBody] String mail)
        {
            try
            {
                var profil = Context.ProfilKorisnikas.Where(x => x.Email == mail).FirstOrDefault();
                if(profil == null)
                {
                    return BadRequest("Profil nije nadjen");
                }
                return Ok(new
                {
                    email = profil.Email,
                    username = profil.Username,
                    brojTelefona = profil.BrojTelefona,
                    adresa = profil.Adresa,
                    datumRodjenja = profil.DatumRodjenja,
                    datumRegistracije = profil.DatumRegistracije,
                    pol = profil.Pol
                });
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("updateData")]
        [HttpPut]
        public async Task<ActionResult> updateData([FromBody] ProfilKorisnika profil)
        {
            try
            {
                var profile = Context.ProfilKorisnikas.Where(pr => pr.Email == profil.Email).FirstOrDefault();
                if (profile == null)
                    return BadRequest("Profil nije pronadjen");
                if (profile.Adresa != profil.Adresa)
                    profile.Adresa = profil.Adresa;
                if(profile.Pol != profil.Pol)
                    profile.Pol = profil.Pol;
                if (profile.Username != profil.Username)
                    profile.Username = profil.Username;
                if (profile.BrojTelefona != profil.BrojTelefona)
                    profile.BrojTelefona = profil.BrojTelefona;
                if (profile.DatumRodjenja != profil.DatumRodjenja)
                    profile.DatumRodjenja = profil.DatumRodjenja;

                Context.ProfilKorisnikas.Update(profile);
                await Context.SaveChangesAsync();

                return Ok(new
                {
                    email = profile.Email,
                    username = profile.Username,
                    brojTelefona = profile.BrojTelefona,
                    adresa = profile.Adresa,
                    datumRodjenja = profile.DatumRodjenja,
                    datumRegistracije = profile.DatumRegistracije,
                    pol = profile.Pol
                });
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("getProfilePhoto")]
        [HttpPost]
        public async Task<ActionResult> getProfilePhoto([FromBody] String email)
        {
            try
            {
                byte[] imgBytes = Context.ProfilKorisnikas
                                         .Where(profil => profil.Email == email)
                                         .Select(i => i.Image)
                                         .FirstOrDefault();
                if(imgBytes == null)
                {
                    return BadRequest("Profilna slika nije pronadjena");
                }
                var memStream = new MemoryStream(imgBytes);
                return File(memStream, "image/jpeg");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [Route("updatePhoto")]
        [HttpPut]
        public async Task<ActionResult> updatePhoto([FromForm] IFormFile image, String email)
        {
            byte[] imageBytes;
            using (var memoryStream = new MemoryStream())
            {
                image.CopyTo(memoryStream);
                imageBytes = memoryStream.ToArray();
            }
            try
            {
                var profile = Context.ProfilKorisnikas
                                         .Where(profil => profil.Email == email)
                                         .FirstOrDefault();
                profile.Image = imageBytes;
                Context.ProfilKorisnikas.Update(profile);
                await Context.SaveChangesAsync();
                var memStream = new MemoryStream(imageBytes);
                return File(memStream, "image/jpeg");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //[Route("setPhoto/{id}")]
        //[HttpPost, Authorize]
        //public async Task<ActionResult> SetPhoto(int id, IFormFile file)
        //{
        //    try
        //    {
        //        var user = Context.ProfilKorisnikas.Where(User => User.Id == id).FirstOrDefault();
        //        if(user == null)
        //        {
        //            return BadRequest("Korisnik nije pronadjen");
        //        }

        //        using(var memoryStream = new MemoryStream())
        //        {
        //            await file.CopyToAsync(memoryStream);
        //            user.Image = memoryStream.ToArray();
        //        }

        //        Context.ProfilKorisnikas.Update(user);
        //        await Context.SaveChangesAsync();
        //        return Ok("Dodata je slika");

        //    }
        //    catch(Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //}
    }
}
