using GiveWaveAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;


namespace GiveWaveAPI.Controllers
{
    [ApiController]
    [Route("controller")]
    public class KategorijeController : ControllerBase
    {
        public GiveWaveDBContext Context { get; set; }
        public KategorijeController(GiveWaveDBContext context)
        {
            Context = context;
        }


        [Route("prikazikategorije")]
        [HttpGet]
        public async Task<ActionResult> prikazikategorije()
        {
            var kategorije = Context.Kategorijes;
            var kateg = kategorije.Include(p => p.Kategorija);

            return Ok(kateg);
        }

        [Route("DodajKategorijuCEKAIJA")]
        [HttpPost]
        public async Task<ActionResult> dodajKategoriju([FromBody] Kategorije kategorije)
        {
            if (kategorije == null)
            {
                return BadRequest("Kategorije is null");
            }
            try
            {
                await Context.Kategorijes.AddAsync(kategorije);
                await Context.SaveChangesAsync();
                return Ok("Kategorija je dodata !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}