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


        //[Route("PreuzmiProfil")]
        //[HttpPost, Authorize]
        //public async Task<ActionResult> PreuzmiProfil([FromBody] String email)
        //{
        //    try
        //    {
        //        var profil = Context.ProfilKorisnikas.Where(korisnik => korisnik.Email == email).FirstOrDefault();
        //        if(profil == null)
        //        {
        //            return BadRequest("profil nije pronajden");
        //        }
        //        return Ok(profil);

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //}

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
