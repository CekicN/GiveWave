using GiveWaveAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GiveWaveAPI.Controllers
{
    [ApiController]
    [Route("controller")]
    public class IgrackaController : ControllerBase
    {
        public GiveWaveDBContext Context { get; set; }
        public IgrackaController(GiveWaveDBContext context)
        {
            Context = context;
        }

        [Route("DodajIgracku")]
        [HttpPost]
        public async Task<ActionResult> dodajIgracku([FromBody] Igracka igracka)
        {
            try
            {
                Context.Igrackas.Add(igracka);
                await Context.SaveChangesAsync();
                return Ok("Igracka je dodata !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("PreuzmiIgracku")]
        [HttpGet]

        public async Task<ActionResult> preuzmiIgracku()
        {
            return Ok(Context.Igrackas);
        }

        [Route("ObrisiIgracku")]
        [HttpDelete]
        public async Task<ActionResult> obrisiIgracku(int id)
        {
            try
            {
                var igracka = Context.Igrackas.Where(p => p.Id == id).FirstOrDefault();
                if (igracka == null)
                {
                    return BadRequest("Ta kategorija ne postoji !");
                }
                else
                {
                    Context.Igrackas.Remove(igracka);
                    await Context.SaveChangesAsync();
                    return Ok("Igracka je obrisana !");
                }


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }

}

