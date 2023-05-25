using GiveWaveAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace GiveWaveAPI.Controllers
{
    [ApiController]
    [Route("controller")]
    public class AdminController : ControllerBase
    {
        public GiveWaveDBContext Context { get; set; }
        public AdminController(GiveWaveDBContext context)
        {
            Context = context;
        }


        [Route("ObrisiKorisnika")]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> obrisiKorisnika(EmailContent email)
        {
            try
            {
                var user = Context.ProfilKorisnikas.Where(p => p.Email == email.Name).FirstOrDefault();
                if (user == null) 
                {
                    return BadRequest("Korisnik ne postoji");
                }
                else 
                {
                    Context.ProfilKorisnikas.Remove(user);
                    await Context.SaveChangesAsync();
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
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> dodajKorisnika([FromBody] ProfilKorisnika profilKorisnika)
        {
            try
            {
                Context.ProfilKorisnikas.Add(profilKorisnika);
                await Context.SaveChangesAsync();
                return Ok("Korisnik je dodat !");
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("IzmeniKorisnika")]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> izmeniKorisnika([FromQuery] ProfilKorisnika profilKorisnika, EmailContent email)
        {
            try
            {
                var korisnikZaPromenu = Context.ProfilKorisnikas.Where(p => p.Email == email.Name).FirstOrDefault();

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

                    await Context.SaveChangesAsync();
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
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> prikaziSveKorisnike()
        {
            try
            {
                var korisnici = await Context.ProfilKorisnikas.ToListAsync();
                return Ok(korisnici);
            }
            catch(Exception ex ) 
            {
                return BadRequest(ex.Message);  
            }
        }


        [Route("PrikaziSveDonacije")]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> prikaziSveDonacije()
        {
            try
            {
                var donacije = await Context.Donacijas.ToListAsync();
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
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> brisanjeNeprikladneDonacije(int id)
        {
            try
            {
                var donacija = await Context.Donacijas.FindAsync(id);
                if(donacija == null)
                {
                    return BadRequest("Donacija nije pronadjena !");
                }
                else
                {
                    bool isNeprikladanSadrzaj = proveriNeprikladanSadraj(donacija);

                    if(isNeprikladanSadrzaj == true)
                    {
                        Context.Donacijas.Remove(donacija);
                        await Context.SaveChangesAsync();
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
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> podrskaKorisnicima(int userId)
        {
            try
            {
                var korisnik = await Context.ProfilKorisnikas.FindAsync(userId);
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

    }
    
}
