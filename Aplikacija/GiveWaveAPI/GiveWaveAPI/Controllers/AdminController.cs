using GiveWaveAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

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
        public async Task<ActionResult> izmeniKorisnika([FromBody] ProfilKorisnika profilKorisnika, EmailContent email)
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


        /*[Route("PrikaziSveKorisnike")]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> prikaziSveKorisnike()
        {
            try
            {
                //logika za dohvacivanje i prikaz svih korisnika
            }
            catch(Exception ex ) 
            {
                return BadRequest(ex.Message);  
            }
        }*/


        /*[Route("PrikaziSveDonacije")]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> prikaziSveDonacije()
        {
            try
            {
                //logika za dohvacivanje i prikaz svih donacija
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }*/

        /*[Route("BrisanjeNeprikladneDonacije")]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> brisanjeNeprikladneDonacije(int/string id)
        {
            try
            {
                //logika za brisanje donacije na osnovu int/string id
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }*/


        /*[Route("PodrskaKorisnicima")]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> podrskaKorisnicima(int userId)
        {
            try
            {
                //logika za prikaz podrske korisniku na osnovu userId
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }*/

    }



    
}
