using GiveWaveAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GiveWaveAPI.Controllers
{
    [ApiController]
    [Route("controller")]
    public class KrvController : ControllerBase
    {
        public GiveWaveDBContext Context { get; set; }
        public KrvController(GiveWaveDBContext context)
        {
            Context = context;
        }

        [Route("DodajKrv")]
        [HttpPost]
        public async Task<ActionResult> dodajKrv([FromBody] Krv krv)
        {
            try
            {
                Context.Krvs.Add(krv);
                await Context.SaveChangesAsync();
                return Ok("Krv je dodata !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("PreuzmiKrv")]
        [HttpGet]

        public async Task<ActionResult> preuzmiKrv()
        {
            return Ok(Context.Krvs);
        }

        [Route("ObrisiKrv")]
        [HttpDelete]
        public async Task<ActionResult> obrisiKrv(int id)
        {
            try
            {
                var krv = Context.Krvs.Where(p => p.Id == id).FirstOrDefault();
                if (krv == null)
                {
                    return BadRequest("Ta kategorija ne postoji !");
                }
                else
                {
                    Context.Krvs.Remove(krv);
                    await Context.SaveChangesAsync();
                    return Ok("Krv je obrisana !");
                }


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
