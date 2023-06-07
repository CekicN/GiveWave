using GiveWaveAPI.Helpers;
using GiveWaveAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace GiveWaveAPI.Controllers
{
    [ApiController]
    [Route("controller")]
    public class ProizvodController : ControllerBase
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
                   kategorija =  addCategory(proizvod.novaKategorija, proizvod.parentKategorija);
                    if (kategorija == null)
                        return BadRequest("Kategorija vec postoji");
                }
                var product = context.Proizvods.Where(p => p.Id == id).FirstOrDefault();


                product.Naziv = proizvod.Naziv;
                product.ProfilKorisnika = user;
                product.Opis = proizvod.Opis;
                product.Mesto = proizvod.Mesto;
                product.Kategorije = kategorija;
                product.status = proizvod.status;
                product.ImageUrl = GetImage(proizvod.emailKorisnika, id);



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
        [NonAction]
        public Kategorija addCategory(string category, string parentCategory)
        {
                var kategorija = context.Kategorijas.Where(c => c.Name == category).FirstOrDefault();
                if (kategorija != null)
                    return null;
                var parent = context.Kategorijas.Where(c => c.Name == parentCategory).FirstOrDefault();
                if (parentCategory != null)
                {
                    var subcategory = new Kategorija
                    {
                        Name = category,
                        parentCategory = parent
                    };

                    context.Kategorijas.Add(subcategory);
                    context.SaveChanges();

                    return subcategory;
                }
                else
                {
                    //parent kategorija

                    var subcategory = new Kategorija
                    {
                        Name = category,
                        parentCategory = null
                    };

                    context.Kategorijas.Add(subcategory);
                    context.SaveChanges();

                    return subcategory;

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
        [Route("getAllProducts")]
        [HttpGet]
        public async Task<ActionResult> getAllProducts()
        {
            try
            {
                var products = await context.Proizvods.Include(p => p.ProfilKorisnika).ToListAsync();
                if (products == null)
                    return BadRequest("products not founded");
                return Ok(products.Select(p => new
                {
                    Id = p.Id,
                    ImageUrl = GetImage(p.ProfilKorisnika.Email, p.Id).Split("|"),
                    Naziv = p.Naziv,
                    Mesto = p.Mesto,
                    Status = p.status,
                    Username = p.ProfilKorisnika.Username,
                    Email = p.ProfilKorisnika.Email
                }));
            }catch(Exception e)
            {
                if(e.InnerException != null)
                {
                    return BadRequest(e.InnerException.Message);
                }
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("getProductsViaCategory/{category}")]
        public async Task<ActionResult> getProductsViaCategory(string category)
        {
            try
            {
                var kategorija = context.Kategorijas.Include(p => p.Subcategories).Include(p => p.Proizvodi).Where(k => k.Name == category).FirstOrDefault();
                if (kategorija == null)
                    return BadRequest("Kategorija ne postoji");

                List<Proizvod> products = new List<Proizvod>();
                if(kategorija.Proizvodi != null)
                    products.AddRange(kategorija.Proizvodi);

                AddProductRecursive(kategorija, products);

                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        private void AddProductRecursive(Kategorija kategorija, List<Proizvod> products)
        {
                if(kategorija.Subcategories != null)
                    foreach (var subcategory in kategorija.Subcategories)
                    {
                        if (subcategory.Proizvodi != null)
                            products.AddRange(subcategory.Proizvodi);
                        AddProductRecursive(subcategory, products);
                    }
        }
        [NonAction]
        private string GetFilePath(string email, int code)
        {
            return this._environment.WebRootPath + "\\Uploads\\Products\\" + email + "\\P_" + code;
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

                var product = context.Proizvods.Where(pr => pr.Id == id).FirstOrDefault();
                if (product == null)
                    return BadRequest("Proizvod nije pronadjen");
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

                foreach(var s in files.Select((value, i) => (value,i)))
                {
                    string imagepath = Filepath + "\\image_" + s.i + "_"+ DATE + ".png";
                    using (FileStream stream = System.IO.File.Create(imagepath))
                    {
                        await s.value.CopyToAsync(stream);
                    }
                }
                product.ImageUrl = GetImage(email, id);
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

        [Route("CancleAdding/{id}/{email}")]
        [HttpDelete]
        public async Task<ActionResult> CancleAdding(int id, string email)
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
                    deleteFolder(email, id);
                    return Ok("Proizvod je uspesno obrisan");
                }
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }
        [NonAction]
        private void deleteFolder(string email, int id)
        {
            string path = GetFilePath(email, id);
            if(Directory.Exists(path))
            {
                string[] fajlovi = Directory.GetFiles(path);
                foreach (var fajl in fajlovi)
                {
                    System.IO.File.Delete(fajl);
                }
                Directory.Delete(path);
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
                    status = "",
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
        //da se popravi
        [Route("PrikaziViseInfoOProizvodu/{id}")]
        [HttpGet]
        public async Task<ActionResult> prikaziViseInfoOProizvodima(int id)
        {
            try
            {
                var proizvod = context.Proizvods.Include(p => p.ProfilKorisnika)
                                                .Where(p => p.Id == id)
                                                .FirstOrDefault();
                if (proizvod == null)
                    return BadRequest("proizvod nije nadjen");
                return Ok(new
                {
                         Id = proizvod.Id,
                         Naziv = proizvod.Naziv,
                         Opis = proizvod.Opis,
                         Mesto = proizvod.Mesto,
                         Status = proizvod.status,
                         Profil = proizvod.ProfilKorisnika.Username,
                         Slike = proizvod.ImageUrl.Split('|')
                });
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);   
            }
        }

        //public IEnumerable<Proizvod> GetProizvodByCategory(string kategorija)
        //{
        //    var kategorijaZaPretragu = context.Kategorijas.Where(p => p.Name == kategorija);
        //    var filteredProizvodi = context.Proizvods.Where(p => p.Kategorije == kategorijaZaPretragu);
        //    return filteredProizvodi;
        //}



        //[Route("prikazi odredjene proizvode")]
        //[HttpGet]
        //public async Task<IActionResult> prikaziProizvod
        [Route("PreuzmiProizvodePodkategorija")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiProizvodePodkategorija(string kategorija)
        {
            try
            {
                var kategorijaZaPretragu = await context.Kategorijas
                    .Include(c => c.Subcategories)
                    .Include(c => c.Proizvodi)
                    .Where(c => c.Name == kategorija).FirstOrDefaultAsync();

                if (kategorija == null)
                {
                    return NotFound();
                }

                var proizvodi = new List<Proizvod>();
                DodajProizvodePodkategorija(kategorijaZaPretragu.Subcategories, proizvodi);

                return Ok(proizvodi);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private void DodajProizvodePodkategorija(IEnumerable<Kategorija> subkategorije, List<Proizvod> proizvodi)
        {
            foreach (var subkategorija in subkategorije)
            {
                proizvodi.AddRange(subkategorija.Proizvodi);

                DodajProizvodePodkategorija(subkategorija.Subcategories, proizvodi);
            }
        }
    }


}
