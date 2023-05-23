using GiveWaveAPI.Helpers;
using GiveWaveAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GiveWaveAPI.Controllers
{
    [ApiController]
    [Route("controller")]
    public class ProizvodController : ControllerBase
    {
        public GiveWaveDBContext context { get; set; }
        public ProizvodController(GiveWaveDBContext c)
        {
            context = c;
        }


        [Route("addProduct")]
        [HttpPost]
        public async Task<ActionResult> addProduct([FromBody] ProductHelper proizvod)
        {
            try
            {
                var user = context.ProfilKorisnikas
                .Where(p => p.Email == proizvod.emailKorisnika).FirstOrDefault();
                if (user == null)
                {
                    return BadRequest("Korisnik nije pronadjen");
                }
                else
                {
                    var kategorija = context.Kategorijas
                      .Where(q => q.naziv == proizvod.Kategorija);
                    if (kategorija == null)
                    {
                        return BadRequest("Kategorija ne postoji");
                    }
                    else
                    {
                        var product = new Proizvod();
                        product.Naziv = proizvod.Naziv;
                        product.ProfilKorisnika = user;
                        product.Opis = proizvod.Opis;
                        //product.Kategorije = proizvod.kategorija;

                        context.Proizvods.Add(product);
                        await context.SaveChangesAsync();   
                        return Ok("Proizvod je dodat");
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [Route("VratiProizvodePremaEmailu")]
        [HttpGet]
        public async Task<ActionResult> vratiProizvodePremaEmailu(EmailContent email)
        {
            try
            {
                var user = context.ProfilKorisnikas.Where(p => p.Email == email.Name).FirstOrDefault();
                if (user == null)
                {
                    return BadRequest("Nemoguce je pronaci mail");
                }
                else
                {
                    var prozivodi = user.Proizvodi.ToList();
                    return Ok(prozivodi);
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            
        }

        [Route("ObrisiProizvod")]
        [HttpDelete]
        public async Task<ActionResult> obrisiProizvod(int id)
        {
            try
            {
                var proizvod = context.ProfilKorisnikas
                    .Include(p => p.Proizvodi)
                    .Where(q => q.Id == id)
                    .FirstOrDefault();

                if(proizvod == null)
                {
                    return BadRequest("Proizvod sa tim id-jem ne postoji");
                }
                else
                {
                    context.ProfilKorisnikas.Remove(proizvod);
                    await context.SaveChangesAsync();
                    return Ok("Proizvod je uspesno obrisan");
                }
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [Route("PrikaziViseInfoOProizvodima")]
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
