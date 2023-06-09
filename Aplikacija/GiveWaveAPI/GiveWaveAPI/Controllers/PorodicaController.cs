using Microsoft.AspNetCore.Mvc;
using GiveWaveAPI.Models;
using GiveWaveAPI.Helpers;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace GiveWaveAPI.Controllers
{
    public class PorodicaController : ControllerBase
    {
        private readonly GiveWaveDBContext context;
        private readonly IWebHostEnvironment _environment;
        public PorodicaController(GiveWaveDBContext c, IWebHostEnvironment environment)
        {
            context = c;
            _environment = environment;
        }

        [Route("CancleAddingFamily/{id}/{email}")]
        [HttpDelete]
        public async Task<ActionResult> CancleAdding(int id, string email)
        {
            try
            {
                var family = context.Porodice
                    .Where(q => q.Id == id)
                    .FirstOrDefault();
                if (family == null)
                {
                    return BadRequest("Porodica sa tim id-jem ne postoji");
                }
                else
                {
                    context.Porodice.Remove(family);
                    await context.SaveChangesAsync();
                    deleteFolder(email, id);
                    return Ok();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [NonAction]
        private void deleteFolder(string email, int id)
        {
            string path = GetFilePath(email, id);
            if (Directory.Exists(path))
            {
                string[] fajlovi = Directory.GetFiles(path);
                foreach (var fajl in fajlovi)
                {
                    System.IO.File.Delete(fajl);
                }
                Directory.Delete(path);
            }
        }
        [Route("addEmptyFamily")]
        [HttpPost]
        public async Task<ActionResult> addEmptyProduct()
        {
            try
            {
                var family = new Porodica()
                {
                    Naziv = "",
                    UrlSlika = "",
                    Opis = "",
                    ProfilKorisnika = null,
                    Status = "",
                    Grad = "",
                    Adresa = "",
                    BrClanova = -1,
                    najpotrebnijestvari = ""
                    
                };

                await context.Porodice.AddAsync(family);
                await context.SaveChangesAsync();
                return Ok(family.Id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        [Route("AddFamily/{id}")]
        public async Task<ActionResult> AddFamily(int id, [FromBody] FamilyHelper family)
        {
            try
            {
                var user = context.ProfilKorisnikas.Where(p => p.Email == family.email).FirstOrDefault();
                if (user == null)
                    return BadRequest("Profil nije pronadjen");
                var porodica = context.Porodice.Where(p => p.Id == id).FirstOrDefault();
                if (porodica == null)
                    return BadRequest("Porodica nije nadjena");

                porodica.Naziv = family.Naziv;
                porodica.Adresa = family.Adresa;
                porodica.BrClanova = family.BrClanova;
                porodica.Grad = family.Grad;
                porodica.Opis = family.Opis;
                porodica.ProfilKorisnika = user;
                porodica.Potvrda = false;
                porodica.UrlSlika = GetImage(family.email, id);

                string stvari = "";
                foreach (var stvar in family.najpotrebnijestvari)
                {
                    stvari += stvar + "|";
                }
                stvari = stvari.Substring(0, stvari.Length - 1);
                porodica.najpotrebnijestvari = stvari;
                context.Porodice.Update(porodica);
                await context.SaveChangesAsync();
                return Ok(porodica.Id);
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                    return BadRequest(e.InnerException.Message);
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("getAllFamilies")]
        public async Task<ActionResult> getAllFamilies()
        {
            try
            {
                var validFamilies = context.Porodice
                                           .Include(p => p.ProfilKorisnika)
                                           .Where(p => p.Potvrda == true).ToList();
                if (validFamilies == null)
                    return BadRequest("Nema potvrdjenih porodica");

                return Ok(validFamilies.Select(p => new
                {
                    Id = p.Id,
                    UrlSlika = GetImage(p.ProfilKorisnika.Email, p.Id).Split("|"),
                    Naziv = p.Naziv,
                    Grad = p.Grad,
                    Adresa = p.Adresa,
                    BrClanova = p.BrClanova,
                    Status = p.Status,
                    najpotrebnijestvari = p.najpotrebnijestvari.Split("|"),
                    Email = p.ProfilKorisnika.Email,
                    User = p.ProfilKorisnika.Username
                }));
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        #region Images
        [NonAction]
        private string GetFilePath(string email, int code)
        {
            return this._environment.WebRootPath + "\\Uploads\\Families\\" + email + "\\P_" + code;
        }
        [Route("updatePhoto")]
        [HttpPut]
        public async Task<ActionResult> updateImage()
        {
            try
            {
                var id = Int32.Parse(Request.Form["id"]);
                var email = Request.Form["email"];
                var files = Request.Form.Files;

                var family = context.Porodice.Where(pr => pr.Id == id).FirstOrDefault();
                if (family == null)
                    return BadRequest("Porodica nije pronadjena");
                string Filepath = GetFilePath(email, id);

                if (!System.IO.Directory.Exists(Filepath))
                {
                    System.IO.Directory.CreateDirectory(Filepath);
                }

                string DAT = Convert.ToString(DateTime.Now);

                StringBuilder sb = new StringBuilder(DAT);

                sb.Replace(" ", "_");
                sb.Replace(":", "_");

                var DATE = sb.ToString();


                //Brisanje svega u folderu
                string[] fajlovi = Directory.GetFiles(Filepath);
                foreach (var fajl in fajlovi)
                {
                    System.IO.File.Delete(fajl);
                }

                foreach (var s in files.Select((value, i) => (value, i)))
                {
                    string imagepath = Filepath + "\\image_" + s.i + "_" + DATE + ".png";
                    using (FileStream stream = System.IO.File.Create(imagepath))
                    {
                        await s.value.CopyToAsync(stream);
                    }
                }
                family.UrlSlika = GetImage(email, id);
                context.Porodice.Update(family);
                context.SaveChanges();

                var ListOfUrls = family.UrlSlika.Split('|');
                return Ok(new { UrlSlika = ListOfUrls });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [NonAction]
        private string GetImage(string email, int id)
        {
            string imageUrl = string.Empty;
            string Host = "https://localhost:7200/";
            string Filepath = GetFilePath(email, id);
            List<string> img = new List<string>();

            bool PostojeFajlovi = false;
            string[] imagePaths;
            if (Directory.Exists(Filepath))
            {
                string[] fajlovi = Directory.GetFiles(Filepath, "*.png");
                if (fajlovi.Length > 0)
                {
                    imagePaths = fajlovi;
                    foreach (var imagePath in imagePaths)
                    {
                        img.Add(imagePath.Substring(imagePath.IndexOf("wwwroot") + 7));
                    }
                    PostojeFajlovi = true;
                }
            }

            if (PostojeFajlovi)
            {
                foreach (var image in img)
                {
                    imageUrl += Host + image + "|";
                }
                imageUrl = imageUrl.Substring(0, imageUrl.Length - 1);
            }
            else
            {
                imageUrl = Host + "/uploads/common/noimage.png";
            }
            return imageUrl;
        }
        #endregion
    }
}
