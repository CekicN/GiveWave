using GiveWaveAPI.Helpers;
using GiveWaveAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GiveWaveAPI.Controllers
{
    public class ProizvodController : Controller
    {
        private readonly GiveWaveDBContext context;

        public ProizvodController(GiveWaveDBContext c)
        {
            context = c;
        }


        //[Route("CreateProduct")]
        //[HttpPost]
        //public async Task<ActionResult> CreateProduct([FromBody] ProductHelper proizvod)
        //{
        //    try
        //    {
        //        var user = context.ProfilKorisnikas
        //        .Where(korisnik => korisnik.Email == proizvod.emailKorisnika).FirstOrDefault();
        //        if (user == null)
        //            return BadRequest("Korisnik nije pronadjen");

        //        var kategorija = context.Kategorijas
        //        .Where(kat => kat.Ime == proizvod.Kategorija);
        //        if (kategorija == null)
        //            return BadRequest("Kategorija nije pronadjena");



        //        var product = new Proizvod();
        //        product.Naziv = proizvod.Naziv;
        //        product.ProfilKorisnika = user;
        //        product.Opis = proizvod.Opis;
        //        product.Kategorija = klasa;
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //    return Ok();
        //}

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
            return Ok();
        }
    }
}
