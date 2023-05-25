using GiveWaveAPI.Helpers;
using GiveWaveAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace GiveWaveAPI.Controllers
{
    public class ProizvodController : Controller
    {
        private readonly GiveWaveDBContext context;

        private readonly IWebHostEnvironment _environment;
        public ProizvodController(GiveWaveDBContext c, IWebHostEnvironment environment)
        {
            _environment = environment;
            context = c;
        }


        [Route("addProduct/{id}")]
        [HttpPut]
        public async Task<ActionResult> addProduct([FromBody] ProductHelper proizvod,int id)
        {
            try
            {
                var user = context.ProfilKorisnikas
                                .Where(p => p.Email == proizvod.emailKorisnika).FirstOrDefault();
                if (user == null)
                {
                    return BadRequest("Korisnik nije pronadjen");
                }
                var kategorija = context.Kategorijas.Where(q => q.Name == proizvod.Kategorija).FirstOrDefault();
                if (kategorija == null)
                {
                    //mehanizam za dodavanje nepostojece kategorije ....
                    return BadRequest("Kategorija ne postoji");
                }
                var product = context.Proizvods.Where(p => p.Id == id).FirstOrDefault();


                product.Naziv = proizvod.Naziv;
                product.ProfilKorisnika = user;
                product.Opis = proizvod.Opis;
                product.Mesto = proizvod.Mesto;
                product.Kategorije = kategorija;
                product.status = proizvod.status;
                product.ImageUrl = proizvod.ImageUrl;//ovde treba getImage fja



                context.Proizvods.Update(product);
                await context.SaveChangesAsync();
                return Ok("Proizvod je izmenjen");
            }
            catch (Exception e)
            {
                if(e.InnerException != null)
                {
                    return BadRequest(e.InnerException.Message);
                }
                return BadRequest(e.Message);
            }

        }

        [Route("VratiProizvodePremaEmailu/{email}")]
        [HttpGet]
        public async Task<ActionResult> vratiProizvodePremaEmailu(string email)
        {
            try
            {
                var userAndProducts = context.ProfilKorisnikas
                                             .Include(p => p.Proizvodi)
                                             .Where(p => p.Email == email)
                                             .FirstOrDefault();
                if (userAndProducts == null)
                {
                    return BadRequest("Nemoguce je pronaci mail");
                }
                List<Proizvod> proizvodi;
                if (userAndProducts.Proizvodi != null)
                    proizvodi = userAndProducts.Proizvodi;
                else
                    return BadRequest("Korisnik nema proizvodee");

                return Ok(proizvodi.Select(p => new
                {
                    Id = p.Id,
                    ImageUrl = GetImage(email,p.Id).Split("|"),
                    Naziv = p.Naziv, 
                    Opis = p.Opis
                }));

            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                    return BadRequest(e.InnerException.Message);
                return BadRequest(e.Message);
            }

            
        }
        [NonAction]
        private string GetFilePath(string email, int code)
        {
            return this._environment.WebRootPath + "\\Uploads\\Products\\" + email + "\\P_" + code;
        }
        [Route("updatePhoto")]
        [HttpPut]
        public async Task<ActionResult> updateImage([FromBody] updateImageHelper updateImage)
        {
            try
            {
                var product = context.Proizvods.Where(pr => pr.Id == updateImage.id).FirstOrDefault();
                if (product == null)
                    return BadRequest("Proizvod nije pronadjen");
                string Filepath = GetFilePath(updateImage.email, updateImage.id);

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

                foreach(var s in updateImage.Files.Select((value, i) => (value,i)))
                {
                    string imagepath = Filepath + "\\image_" + s.i + "_"+ DATE + ".png";
                    using (FileStream stream = System.IO.File.Create(imagepath))
                    {
                        await s.value.CopyToAsync(stream);
                    }
                }
                product.ImageUrl = GetImage(updateImage.email, updateImage.id);
                context.Proizvods.Update(product);
                context.SaveChanges();

                var ListOfUrls = product.ImageUrl.Split('|');
                return Ok(new { imageUrls = ListOfUrls});
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
                    foreach(var imagePath in imagePaths)
                    {
                        img.Add(imagePath.Substring(imagePath.IndexOf("wwwroot") + 7));
                    }
                    PostojeFajlovi = true;
                }
            }

            if(PostojeFajlovi)
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

        [Route("CancleAdding/{id}")]
        [HttpDelete]
        public async Task<ActionResult> CancleAdding(int id)
        {
            try
            {
                var proizvod = context.Proizvods
                    .Where(q => q.Id == id)
                    .FirstOrDefault();

                if(proizvod == null)
                {
                    return BadRequest("Proizvod sa tim id-jem ne postoji");
                }
                else
                {
                    context.Proizvods.Remove(proizvod);
                    await context.SaveChangesAsync();
                    return Ok("Proizvod je uspesno obrisan");
                }
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [Route("addEmptyProduct")]
        [HttpPost]
        public async Task<ActionResult> addEmptyProduct()
        {
            try
            {
                var product = new Proizvod()
                {
                    Naziv = "",
                    ImageUrl = "",
                    Opis = "",
                    ProfilKorisnika = null,
                    status = 0,
                    Mesto = "",
                    Kategorije = null
                };

                await context.Proizvods.AddAsync(product);
                await context.SaveChangesAsync();
                return Ok(product.Id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("PrikaziViseInfoOProizvodu")]
        [HttpGet]
        public async Task<ActionResult> prikaziViseInfoOProizvodima(int id)
        {
            try
            {
                var productInfo = context.Proizvods;
                return Ok(productInfo);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);   
            }
        }
    }

    
}
