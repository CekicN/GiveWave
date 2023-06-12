using GiveWaveAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GiveWaveAPI.Helpers;
namespace GiveWaveAPI.Controllers
{
    public class DonacijaController : ControllerBase
    {
        private readonly GiveWaveDBContext context;

        public DonacijaController(GiveWaveDBContext c)
        {
            context = c;
        }
        
        [Route("VratiSveDonacije")]
        [HttpGet]
        public async Task<ActionResult> vratiSveDonacije()
        {
            try
            {
                var donacije = context.Donacijas.ToListAsync();
                await context.SaveChangesAsync();
                return Ok(donacije);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("Donate")]
        public async Task<ActionResult> Donate([FromBody] DonateHelper donate)
        {
            try
            {
                var profil = context.ProfilKorisnikas.Where(p=> p.Email == donate.email).FirstOrDefault();
                if (profil == null)
                    return BadRequest("Profil nije nadjen");

                var porodica = context.Porodice.Where(p => p.Id == donate.idPorodice).FirstOrDefault();
                if (porodica == null)
                    return BadRequest("Porodica nije nadjena");

                string[] supplies = porodica.najpotrebnijestvari.Split("|");
                string[] ostaleStvari = getModifiedSupplies(supplies, donate.donacija.ToArray());
                string stvari = "";
                if (ostaleStvari != null)
                {
                    foreach (var stvar in ostaleStvari)
                    {
                        stvari += stvar + "|";
                    }
                    stvari = stvari.Substring(0, stvari.Length - 1);
                }
                else
                    stvari = "";

                
                porodica.najpotrebnijestvari = stvari;
                context.Porodice.Update(porodica);

                stvari = "";
                foreach (var stvar in donate.donacija)
                {
                    stvari += stvar + "|";
                }
                stvari = stvari.Substring(0, stvari.Length - 1);

                var donacija = new Donacija()
                {
                    DatumDonacije = DateTime.Now,
                    Opis = donate.Opis,
                    Porodica = porodica,
                    donacija = stvari,
                    ProfilKorisnika = profil
                };

                await context.Donacijas.AddAsync(donacija);
                await context.SaveChangesAsync();
                return Ok(donacija);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [NonAction]
        private string[] getModifiedSupplies(string[] supplies1, string[] supplies2)
        {
            if (supplies1.Length == 1 && supplies2.Length == 1)
                return null;
            List<string> modifiedSupplies = new List<string>();

            foreach (string supply in supplies1)
            {
                if (!supplies2.Contains(supply))
                {
                    modifiedSupplies.Add(supply);
                }
            }

            return modifiedSupplies.ToArray();
        }

        [HttpGet]
        [Route("getSupplies/{id}")]
        public async Task<ActionResult> getSupplies(int id)
        {
            try
            {
                var porodica = context.Porodice.Where(q => q.Id == id).FirstOrDefault();
                if (porodica == null)
                    return BadRequest("Porodica nije nadjena");
                string[] supplies = porodica.najpotrebnijestvari.Split("|");
                return Ok(supplies);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}