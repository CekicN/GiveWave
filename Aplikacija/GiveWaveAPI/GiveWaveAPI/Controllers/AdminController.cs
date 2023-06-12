
using GiveWaveAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace GiveWaveAPI.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("controller")]
    [Authorize(Roles ="Admin")]
    
    public class AdminController : ControllerBase
    {
        public GiveWaveDBContext _context { get; set; }
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IWebHostEnvironment _environment;
        public AdminController(GiveWaveDBContext context, UserManager<IdentityUser> userManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager,SignInManager<IdentityUser> signInManager, IWebHostEnvironment environment)
        {
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _environment = environment;
        }


        [Route("ObrisiKorisnika/{email}")]
        [HttpDelete]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> obrisiKorisnika(string email)
        {
            try
            {
                var user = _context.ProfilKorisnikas.Where(p => p.Email == email).FirstOrDefault();
                if (user == null) 
                {
                    return BadRequest("Korisnik ne postoji");
                }
                else 
                {
                    _context.ProfilKorisnikas.Remove(user);
                    await _context.SaveChangesAsync();
                    return Ok("Korisnik je uspesno obrisan !");
                }

            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }

        }

        [Route("DodajKorisnika")]
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> dodajKorisnika([FromBody] ProfilKorisnika profilKorisnika)
        {
            try
            {
                _context.ProfilKorisnikas.Add(profilKorisnika);
                await _context.SaveChangesAsync();
                return Ok("Korisnik je dodat !");
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("IzmeniKorisnika")]
        [HttpPut]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> izmeniKorisnika([FromQuery] ProfilKorisnika profilKorisnika, EmailContent email)
        {
            try
            {
                var korisnikZaPromenu = _context.ProfilKorisnikas.Where(p => p.Email == email.Name).FirstOrDefault();

                if(korisnikZaPromenu == null) 
                {
                    return BadRequest("Korisnik nije pronadjen");
                }
                else
                {
                    korisnikZaPromenu.Username = profilKorisnika.Username;
                    korisnikZaPromenu.Email = profilKorisnika.Email;
                    korisnikZaPromenu.BrojLajkova = profilKorisnika.BrojLajkova;
                    korisnikZaPromenu.BrojTelefona = profilKorisnika.BrojTelefona;
                    korisnikZaPromenu.Adresa = profilKorisnika.Adresa;
                    korisnikZaPromenu.DatumRodjenja = profilKorisnika.DatumRodjenja;
                    korisnikZaPromenu.Pol = profilKorisnika.Pol;
                    korisnikZaPromenu.StatusAktivnosti = profilKorisnika.StatusAktivnosti;
                    korisnikZaPromenu.ImageUrl = profilKorisnika.ImageUrl;
                    korisnikZaPromenu.DatumRegistracije = profilKorisnika.DatumRegistracije;

                    await _context.SaveChangesAsync();
                    return Ok("Uspesno ste izmenili korisnika");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }


        [Route("PrikaziSveKorisnike")]
        [HttpGet]
       // [Authorize(Roles = "Admin")]
        public async Task<ActionResult> prikaziSveKorisnike()
        {
            try
            {
                var korisnici = await _context.ProfilKorisnikas.ToListAsync();
                return Ok(korisnici);
            }
            catch(Exception ex ) 
            {
                return BadRequest(ex.Message);  
            }
        }


        [Route("PrikaziSveDonacije")]
        [HttpGet]
       // [Authorize(Roles = "Admin")]
        public async Task<ActionResult> prikaziSveDonacije()
        {
            try
            {
                var donacije = await _context.Donacijas.ToListAsync();
                return Ok(donacije);    
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        private bool proveriNeprikladanSadraj(Donacija donacija)
        {
             if(donacija.Opis.Contains("Majmun") || donacija.Opis.Contains("Govedo") || donacija.Opis.Contains("Volina"))
             {
                return true;
             }
             else
             {
                return false;
             }
        }

        [Route("BrisanjeNeprikladneDonacije")]
        [HttpDelete]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> brisanjeNeprikladneDonacije(int id)
        {
            try
            {
                var donacija = await _context.Donacijas.FindAsync(id);
                if(donacija == null)
                {
                    return BadRequest("Donacija nije pronadjena !");
                }
                else
                {
                    bool isNeprikladanSadrzaj = proveriNeprikladanSadraj(donacija);

                    if(isNeprikladanSadrzaj == true)
                    {
                        _context.Donacijas.Remove(donacija);
                        await _context.SaveChangesAsync();
                        return Ok("Donacija je obrisana zbog neprikladnog sadrzaja !");
                    }
                    else
                    {
                        return Ok("Donacija je ok");
                    }
                }
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [Route("PodrskaKorisnicima")]
        [HttpGet]
       // [Authorize(Roles = "Admin")]
        public async Task<ActionResult> podrskaKorisnicima(int userId)
        {
            try
            {
                var korisnik = await _context.ProfilKorisnikas.FindAsync(userId);
                if(korisnik == null)
                {
                    return BadRequest("Korisnik nije pronadjen !");

                }
                else
                {
                    //prikaz podrske korisniku kada se prijavi
                    var poruka = "Hvala vam na korištenju naše aplikacije. Ako imate bilo kakva pitanja ili trebate pomoć, slobodno nas kontaktirajte.";
                    return Ok(poruka);

                }
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }
        [Route("SuspendujKorisnika")]
        //[Authorize(Roles ="Admin")]
        [HttpPut]
        public async Task<IActionResult> SuspendUser(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.MaxValue);
                await _signInManager.SignOutAsync();
                return Ok("Uspesno suspendovan");
            }
            else
            {
                return BadRequest("Korisnik NIJE suspendovan");
            }
        }
        [Authorize(Roles ="Admin")]
        [Route("PromeniRolu/{username}")]
        [HttpPut]
        public async Task<IActionResult> ChangeRole(string userName)
        {
            var userExist = await _userManager.FindByNameAsync(userName);
            if (userExist == null)
            {
                return BadRequest("User ne postoji");
            }
            else
            {

                var result = await _userManager.RemoveFromRoleAsync(userExist, "User");
                if(result.Succeeded)
                {
                    result = await _userManager.AddToRoleAsync(userExist, "Service");
                    return Ok("Uspesna promena");
                }
                else
                {
                    return BadRequest("Nesupesna promena");
                }
            }
        }
        //[Authorize(Roles ="Admin")]
        //[Route("getAllProducts")]
        //[HttpGet]
        //public async Task<ActionResult> getAllProducts()
        //{
        //    try
        //    {
        //        var products = await _context.Proizvods.Include(p => p.ProfilKorisnika).ToListAsync();
        //        if (products == null)
        //            return BadRequest("products not founded");
        //        return Ok(products.Select(p => new
        //        {
        //            Id = p.Id,
        //            ImageUrl = GetImage(p.ProfilKorisnika.Email, p.Id).Split("|"),
        //            Naziv = p.Naziv,
        //            Mesto = p.Mesto,
        //            Status = p.status,
        //            Username = p.ProfilKorisnika.Username,
        //            Email = p.ProfilKorisnika.Email
        //        }));
        //    }
        //    catch (Exception e)
        //    {
        //        if (e.InnerException != null)
        //        {
        //            return BadRequest(e.InnerException.Message);
        //        }
        //        return BadRequest(e.Message);
        //    }
        //}
        //[NonAction]
        //private string GetImage(string email, int id)
        //{
        //    string imageUrl = string.Empty;
        //    string Host = "https://localhost:7200/";
        //    string Filepath = GetFilePath(email, id);
        //    List<string> img = new List<string>();

        //    bool PostojeFajlovi = false;
        //    string[] imagePaths;
        //    if (Directory.Exists(Filepath))
        //    {
        //        string[] fajlovi = Directory.GetFiles(Filepath, "*.png");
        //        if (fajlovi.Length > 0)
        //        {
        //            imagePaths = fajlovi;
        //            foreach (var imagePath in imagePaths)
        //            {
        //                img.Add(imagePath.Substring(imagePath.IndexOf("wwwroot") + 7));
        //            }
        //            PostojeFajlovi = true;
        //        }
        //    }

        //    if (PostojeFajlovi)
        //    {
        //        foreach (var image in img)
        //        {
        //            imageUrl += Host + image + "|";
        //        }
        //        imageUrl = imageUrl.Substring(0, imageUrl.Length - 1);
        //    }
        //    else
        //    {
        //        imageUrl = Host + "/uploads/common/noimage.png";
        //    }
        //    return imageUrl;
        //}
        //[NonAction]
        //private string GetFilePath(string email, int code)
        //{
        //    return this._environment.WebRootPath + "\\Uploads\\Products\\" + email + "\\P_" + code;
        //}
    }
    
}
