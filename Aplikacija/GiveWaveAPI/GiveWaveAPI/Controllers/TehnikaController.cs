using GiveWaveAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GiveWaveAPI.Controllers
{
    [ApiController]
    [Route("controller")]
    public class TehnikaController : ControllerBase
    {
        public GiveWaveDBContext Context { get; set; }
        public TehnikaController(GiveWaveDBContext context)
        {
            Context = context;
        }

        [Route("DodajTehniku")]
        [HttpPost]
        public async Task<ActionResult> dodajTehniku([FromBody] Tehnika tehnika)
        {
            try
            {
                Context.Tehnikas.Add(tehnika);
                await Context.SaveChangesAsync();
                return Ok("Tehnika je dodata !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("PreuzmiTehniku")]
        [HttpGet]

        public async Task<ActionResult> preuzmiTehniku()
        {
            return Ok(Context.Tehnikas);
        }

        [Route("ObrisiTehniku")]
        [HttpDelete]
        public async Task<ActionResult> obrisiTehniku(int id)
        {
            try
            {
                var tehnika = Context.Tehnikas.Where(p => p.Id == id).FirstOrDefault();
                if (tehnika == null)
                {
                    return BadRequest("Ta kategorija ne postoji !");
                }
                else
                {
                    Context.Tehnikas.Remove(tehnika);
                    await Context.SaveChangesAsync();
                    return Ok("Tehnika je obrisana !");
                }


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
