using GiveWaveAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GiveWaveAPI.Controllers
{
    [ApiController]
    [Route("controller")]
    public class OdecaController : ControllerBase
    {
        public GiveWaveDBContext Context { get; set; }
        public OdecaController(GiveWaveDBContext context)
        {
            Context = context;
        }

        [Route("DodajOdecu")]
        [HttpPost]
        public async Task<ActionResult> dodajOdecu([FromBody] Odeca odeca)
        {
            try
            {
                Context.Odecas.Add(odeca);
                await Context.SaveChangesAsync();
                return Ok("Odeca je dodata !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("PreuzmiOdecu")]
        [HttpGet]

        public async  Task<ActionResult> preuzmiOdecu()
        {
            return  Ok(Context.Odecas);
        }

        [Route("ObrisiOdecu")]
        [HttpDelete]
        public async Task<ActionResult> obrisiOdecu(string id)
        {
            try
            {
                var odeca = Context.Odecas.Where(p => p.Id == id).FirstOrDefault();
                if (odeca == null)
                {
                    return BadRequest("Ta kategorija ne postoji !");
                }
                else
                {
                    Context.Odecas.Remove(odeca);
                    await Context.SaveChangesAsync();
                    return Ok("Odeca je obrisana !");
                }


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }

}