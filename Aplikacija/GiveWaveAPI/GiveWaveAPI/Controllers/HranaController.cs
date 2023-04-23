using GiveWaveAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GiveWaveAPI.Controllers
{
    [ApiController]
    [Route("controller")]
    public class HranaController : ControllerBase
    {
        public GiveWaveDBContext Context { get; set; }
        public HranaController(GiveWaveDBContext context)
        {
            Context = context;
        }

        [Route("DodajHranu")]
        [HttpPost]
        public async Task<ActionResult> dodajHranu([FromBody] Hrana hrana)
        {
            try
            {
                Context.Hranas.Add(hrana);
                await Context.SaveChangesAsync();
                return Ok("Hrana je dodata !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("PreuzmiHranu")]
        [HttpGet]

        public async Task<ActionResult> preuzmiHranu()
        {
            return Ok(Context.Hranas);
        }


        [Route("ObrisiHranu")]
        [HttpDelete]
        public async Task<ActionResult> obrisiHranu(int id)
        {
            try
            {
                var hrana = Context.Hranas.Where(p => p.Id == id).FirstOrDefault();
                if (hrana == null)
                {
                    return BadRequest("Ta kategorija ne postoji !");
                }
                else
                {
                    Context.Hranas.Remove(hrana);
                    await Context.SaveChangesAsync();
                    return Ok("Hrana je obrisana !");
                }


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }



}

