using GiveWaveAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GiveWaveAPI.Controllers
{
    [ApiController]
    [Route("controller")]
    public class ObucaController : ControllerBase
    {
        public GiveWaveDBContext Context { get; set; }
        public ObucaController(GiveWaveDBContext context)
        {
            Context = context;
        }

        [Route("DodajObucu")]
        [HttpPost]
        public async Task<ActionResult> dodajObucu([FromBody] Obuca obuca)
        {
            try
            {
                Context.Obucas.Add(obuca);
                await Context.SaveChangesAsync();
                return Ok("Obuca je dodata !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("PreuzmiObucu")]
        [HttpGet]

        public async Task<ActionResult> preuzmiObucu()
        {
            return Ok(Context.Obucas);
        }

        [Route("ObrisiObucu")]
        [HttpDelete]
        public async Task<ActionResult> obrisiObucu(int id)
        {
            try
            {
                var obuca = Context.Obucas.Where(p => p.Id == id).FirstOrDefault();
                if (obuca == null)
                {
                    return BadRequest("Ta kategorija ne postoji !");
                }
                else
                {
                    Context.Obucas.Remove(obuca);
                    await Context.SaveChangesAsync();
                    return Ok("Obuca je obrisana !");
                }


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
