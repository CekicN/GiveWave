using GiveWaveAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GiveWaveAPI.Controllers
{
    [ApiController]
    [Route("controller")]
    public class OstaloController : ControllerBase
    {
        public GiveWaveDBContext Context { get; set; }
        public OstaloController(GiveWaveDBContext context)
        {
            Context = context;
        }

        [Route("DodajOstalo")]
        [HttpPost]
        public async Task<ActionResult> dodajOstalo([FromBody] Ostalo ostalo)
        {
            try
            {
                Context.Ostalos.Add(ostalo);
                await Context.SaveChangesAsync();
                return Ok("Ostalo je dodato !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("PreuzmiOstalo")]
        [HttpGet]

        public async Task<ActionResult> preuzmiOstalo()
        {
            return Ok(Context.Ostalos);
        }

        [Route("ObrisiOstalo")]
        [HttpDelete]
        public async Task<ActionResult> obrisiOstalo(int id)
        {
            try
            {
                var ostalo = Context.Ostalos.Where(p => p.Id == id).FirstOrDefault();
                if (ostalo == null)
                {
                    return BadRequest("Ta kategorija ne postoji !");
                }
                else
                {
                    Context.Ostalos.Remove(ostalo);
                    await Context.SaveChangesAsync();
                    return Ok("Ostalo je obrisano !");
                }


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
