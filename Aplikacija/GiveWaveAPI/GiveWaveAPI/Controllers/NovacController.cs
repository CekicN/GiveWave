using GiveWaveAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GiveWaveAPI.Controllers
{
    [ApiController]
    [Route("controller")]
    public class NovacController : ControllerBase
    {
        public GiveWaveDBContext Context { get; set; }
        public NovacController(GiveWaveDBContext context)
        {
            Context = context;
        }

        [Route("DodajNovac")]
        [HttpPost]
        public async Task<ActionResult> dodajNovac([FromBody] Novac novac)
        {
            try
            {
                Context.Novacs.Add(novac);
                await Context.SaveChangesAsync();
                return Ok("Novac je dodat !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("PreuzmiNovac")]
        [HttpGet]

        public async Task<ActionResult> preuzmiNovac()
        {
            return Ok(Context.Novacs);
        }

        [Route("ObrisiNovac")]
        [HttpDelete]
        public async Task<ActionResult> obrisiNovac(int id)
        {
            try
            {
                var novac = Context.Novacs.Where(p => p.Id == id).FirstOrDefault();
                if (novac == null)
                {
                    return BadRequest("Ta kategorija ne postoji !");
                }
                else
                {
                    Context.Novacs.Remove(novac);
                    await Context.SaveChangesAsync();
                    return Ok("Novac je obrisan !");
                }


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
