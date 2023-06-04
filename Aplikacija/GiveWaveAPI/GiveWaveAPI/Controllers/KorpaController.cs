using GiveWaveAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GiveWaveAPI.Controllers
{
    [ApiController]
    [Route("controller")]
    public class KorpaController : ControllerBase
    {
        public GiveWaveDBContext Context { get; set; }
        public KorpaController(GiveWaveDBContext context)
        {
            Context = context;
        }

        private List<Proizvod> proizvodiUKorpi;
        
        public KorpaController() 
        {
            proizvodiUKorpi = new List<Proizvod>();
        }

        [Route("PrikaziProizvode")]
        [HttpGet]
        [Authorize(Roles = "Prijatelj")]
        public async Task<ActionResult> prikaziProizvode(EmailContent email)
        {
            try
            {
                var user = Context.ProfilKorisnikas.Where(p => p.Email == email.Name).FirstOrDefault();
                if (user == null) 
                {
                    return BadRequest("Ne postoji user sa takvim email-om");
                }
                else
                {
                    return Ok(user.Proizvodi);
                }
              

 
            }
            catch(Exception ex) 
            {
                return BadRequest("Ugrozeni nije izabrao nijedan proizvod !");
            }
        }

        [Route("DodajUKorpu")]
        [HttpPost]
        [Authorize(Roles = "Prijatelj")]
        public async Task<ActionResult> dodajUKorpu(Proizvod proizvod)
        {
            try
            {
                proizvodiUKorpi.Add(proizvod);
                return Ok("Dodali ste proizvod u korpi !");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
