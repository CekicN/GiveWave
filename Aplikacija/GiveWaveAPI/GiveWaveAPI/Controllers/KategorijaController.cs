using GiveWaveAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace GiveWaveAPI.Controllers
{
    [ApiController]
    [Route("controller")]
    public class KategorijaController : ControllerBase
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
            if (kategorija == null)
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

        [Route("ObrisiKategoriju")]
        [HttpDelete]
        public async Task<ActionResult> obrisiKategoriju(int id)
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


        /*[Route("VratiSveKategorije")]
        [HttpGet]
        public async Task<ActionResult> vratiSveKategorije()
        {
            try
            {
                var kategorije = Context.Kategorijas;
                if (kategorije == null)
                {
                    return BadRequest("Nisu pronadjene kategorije");
                }
                else
                {
                    var sveKat = kategorije.Include(p => p.Igracka)
                                            .ThenInclude(e => e.kategorija)
                                            .Include(q => q.Novac)
                                            .ThenInclude(r => r.kategorija)
                                            .Include(w => w.Odeca)
                                            .ThenInclude(i => i.kategorija)
                                            .Include(y => y.Ostalo)
                                            .ThenInclude(l => l.kategorija)
                                             .Include(o => o.Krv);
                                                       


                    return Ok(sveKat);
                }
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);

            }

        }*/

        [Route("VratiSveKategorije")]
        [HttpGet]
        public async Task<ActionResult> vratiSveKategorije()
        {
            try
            {
                var sveKategorije = Context.Kategorijas;

                return Ok(sveKategorije);
                
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }



    }
}
