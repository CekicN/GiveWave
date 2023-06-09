using GiveWaveAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace GiveWaveAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
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
                    lajkovi = profil.BrojLajkova,
                    imageUrl = GetImage(mail)
                });
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("updateUsername")]
        [HttpPut]
        public async Task<ActionResult> updateUsername([FromBody] ChangeData change)
        {
            var profil = Context.ProfilKorisnikas.Where(pr => pr.Email == change.email).FirstOrDefault();
            try
            {
                if(profil == null)
                {
                    return BadRequest("Profil nije nadjen");
                }
                if (profil.Username == change.data)
                    return BadRequest("Isti je data");
                profil.Username = change.data;
                Context.ProfilKorisnikas.Update(profil);
                await Context.SaveChangesAsync();
                return Ok(profil);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("updatePhoneNumber")]
        [HttpPut]
        public async Task<ActionResult> updateNumber([FromBody] ChangeData change)
        {
            var profil = Context.ProfilKorisnikas.Where(pr => pr.Email == change.email).FirstOrDefault();
            try
            {
                if (profil == null)
                {
                    return BadRequest("Profil nije nadjen");
                }
                if (profil.BrojTelefona == change.data)
                    return BadRequest("Isti je data");
                profil.BrojTelefona = change.data;
                Context.ProfilKorisnikas.Update(profil);
                await Context.SaveChangesAsync();
                return Ok(profil);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("updateAddress")]
        [HttpPut]
        public async Task<ActionResult> updateAddress([FromBody] ChangeData change)
        {
            var profil = Context.ProfilKorisnikas.Where(pr => pr.Email == change.email).FirstOrDefault();
            try
            {
                if (profil == null)
                {
                    return BadRequest("Profil nije nadjen");
                }
                if (profil.Adresa == change.data)
                    return BadRequest("Isti je data");
                profil.Adresa = change.data;
                Context.ProfilKorisnikas.Update(profil);
                await Context.SaveChangesAsync();
                return Ok(profil);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("updateGender")]
        [HttpPut]
        public async Task<ActionResult> updateGender([FromBody] ChangeData change)
        {
            var profil = Context.ProfilKorisnikas.Where(pr => pr.Email == change.email).FirstOrDefault();
            try
            {
                if (profil == null)
                {
                    return BadRequest("Profil nije nadjen");
                }
                if (profil.Pol == change.data)
                    return BadRequest("Isti je data");
                profil.Pol = change.data;
                Context.ProfilKorisnikas.Update(profil);
                await Context.SaveChangesAsync();
                return Ok(profil);
            }
            catch (Exception e)
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

                string DAT = Convert.ToString(DateTime.Now);

                StringBuilder sb = new StringBuilder(DAT);

                sb.Replace(" ", "_");
                sb.Replace(":", "_");

                var DATE = sb.ToString();

                string imagepath = Filepath + "\\image_"+DATE+".png";


                //Brisanje svega u folderu
                string[] fajlovi = Directory.GetFiles(Filepath);
                foreach (var fajl in fajlovi)
                {
                    System.IO.File.Delete(fajl);
                }

                using (FileStream stream = System.IO.File.Create(imagepath))
                {
                    await source.CopyToAsync(stream);
                    Results = true;
                }
                profile.ImageUrl = GetImage(email);
                Context.ProfilKorisnikas.Update(profile);
                Context.SaveChanges();
                return Ok(new { imageUrl = profile.ImageUrl });
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
            string imagePath = "";
            string img = "";
            if(Directory.Exists(Filepath))
            {
                string[] fajlovi = Directory.GetFiles(Filepath, "*.png");
                if (fajlovi.Length > 0)
                {
                    imagePath = fajlovi[0];
                    img = imagePath.Substring(imagePath.IndexOf("wwwroot") + 7);
                }
            }
             
            if(!System.IO.File.Exists(imagePath))
            {
                imageUrl = Host + "/uploads/common/noimage.png";
            }
            else
            {
                imageUrl = Host+ img;
            }
            return imageUrl;
        }

        [Route("Like/{email}")]
        [HttpPatch]
        public async Task<ActionResult> Like(string email)
        {
            try
            {
                var profil = Context.ProfilKorisnikas.Where(profil => profil.Email == email).FirstOrDefault();
                if (profil == null)
                    return BadRequest("Profil nije nadjen");
                profil.BrojLajkova++;
                Context.ProfilKorisnikas.Update(profil);
                await Context.SaveChangesAsync();
                return Ok(profil.BrojLajkova);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("Dislike/{email}")]
        [HttpPatch]
        public async Task<ActionResult> Dislike(string email)
        {
            try
            {
                var profil = Context.ProfilKorisnikas.Where(profil => profil.Email == email).FirstOrDefault();
                if (profil == null)
                    return BadRequest("Profil nije nadjen");
                profil.BrojLajkova--;

                if (profil.BrojLajkova < 0)
                    profil.BrojLajkova = 0;
                Context.ProfilKorisnikas.Update(profil);
                await Context.SaveChangesAsync();
                return Ok(profil.BrojLajkova);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
