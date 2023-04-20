using GiveWaveAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

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
                return Ok("Kategorija je dodata");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("PreuzmiKategoriju")]
        [HttpGet]

        public async Task<ActionResult> preuzmi()
        {
            return Ok(Context.Kategorijas);
        }

    }
}
