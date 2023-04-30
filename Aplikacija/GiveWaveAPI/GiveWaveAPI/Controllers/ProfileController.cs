﻿using GiveWaveAPI.Models;
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
        private readonly IWebHostEnvironment _environment;
        public ProfileController(GiveWaveDBContext context, IWebHostEnvironment environment)
        {
            _environment = environment;
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
                    pol = profil.Pol,
                    imageUrl = GetImage(mail)
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

        [NonAction]
        private string GetFilePath(string email)
        {
            return this._environment.WebRootPath + "\\Uploads\\Profile\\" + email;
        }
        [Route("updatePhoto/{email}")]
        [HttpPut]
        public async Task<ActionResult> updateImage(IFormFile source, String email)
        {
            bool Results = false;
            try
            {
                var profile = Context.ProfilKorisnikas.Where(pr => pr.Email == email).FirstOrDefault();
                if (profile == null)
                    return BadRequest("Profil nije pronadjen");
                string Filename = source.FileName;
                string Filepath = GetFilePath(email);

                if (!System.IO.Directory.Exists(Filepath))
                {
                    System.IO.Directory.CreateDirectory(Filepath);
                }

                string imagepath = Filepath + "\\image.png";

                if (System.IO.File.Exists(imagepath))
                {
                    System.IO.File.Delete(imagepath);
                }
                using (FileStream stream = System.IO.File.Create(imagepath))
                {
                    await source.CopyToAsync(stream);
                    Results = true;
                }
                profile.ImageUrl = GetImage(email);
                Context.ProfilKorisnikas.Update(profile);
                await Context.SaveChangesAsync();
                return Ok(profile.ImageUrl);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
        //[HttpGet("RemoveImage")]
        //public async Task<ActionResult> RemoveImage(string email)
        //{
        //    string FilePath = GetFilePath(email);
        //    string ImagePath = FilePath + "\\image.png";
        //    try
        //    {
        //        if (System.IO.File.Exists(ImagePath))
        //        {
        //            System.IO.File.Delete(ImagePath);
        //        }
        //        return Ok(email);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}
        [NonAction]
        private string GetImage(string email)
        {
            string imageUrl = string.Empty;
            string Host = "https://localhost:7200/";
            string Filepath = GetFilePath(email);
            string imagePath = Filepath + "\\image.png";
            if(!System.IO.File.Exists(imagePath))
            {
                imageUrl = Host + "/uploads/common/noimage.png";
            }
            else
            {
                imageUrl = Host + "/uploads/Profile/" + email + "/image.png";
            }
            return imageUrl;
        }
    }
}