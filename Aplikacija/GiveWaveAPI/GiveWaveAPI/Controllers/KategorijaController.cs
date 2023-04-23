using GiveWaveAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Text.Json;

namespace GiveWaveAPI.Controllers
{
    [ApiController]
    [Route("controller")]
    public class KategorijaController:ControllerBase
    {
        public GiveWaveDBContext Context { get; set; }
        public KategorijaController(GiveWaveDBContext context) 
        {
            Context = context;
        }

        [Route("DodajKategoriju")]
        [HttpPost]
        public async Task<ActionResult> dodajKategoriju([FromBody] Kategorija kategorija)
        {
            if(kategorija == null)
            {
                return BadRequest("Kategorija is null");
            }
            try
            {
                await Context.Kategorijas.AddAsync(kategorija);
                await Context.SaveChangesAsync();
                return Ok("Kategorija je dodata !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("PreuzmiKategoriju")]
        [HttpGet, Authorize]

        public async Task<ActionResult> preuzmiKategoriju()
        {
            return Ok(Context.Kategorijas);
        }

        [Route("ObrisiKategoriju")]
        [HttpDelete]
        public async Task<ActionResult> obrisiKategoriju(string id)
        {
            try
            {
                var kategorija = Context.Kategorijas.Where(p => p.Id == id).FirstOrDefault();
                if (kategorija == null)
                {
                    return BadRequest("Ta kategorija ne postoji !");
                }
                else
                {
                    Context.Kategorijas.Remove(kategorija);
                    await Context.SaveChangesAsync();
                    return Ok("Kategorija je obrisana !");
                }

               
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }
    }
}
