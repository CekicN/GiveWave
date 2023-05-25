using GiveWaveAPI.Helpers;
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
        public async Task<ActionResult> dodajKategoriju([FromBody] CategoryHelper category)
        {
           try
           {
                var kategorija = Context.Kategorijas.Where(c => c.Name == category.category).FirstOrDefault();
                if (kategorija != null)
                    return BadRequest("Kategorija vec postoji");
                var parentCategory = Context.Kategorijas.Where(c => c.Name == category.parentCategory).FirstOrDefault();
                if(parentCategory != null)
                {
                    var subcategory = new Kategorija
                    {
                        Name = category.category,
                        parentCategory = parentCategory
                    };

                    Context.Kategorijas.Add(subcategory);
                    await Context.SaveChangesAsync();

                    return Ok("Dodata je kategorija");
                }
                else
                {
                    //parent kategorija

                    var subcategory = new Kategorija
                    {
                        Name = category.category,
                        parentCategory = null
                    };

                    Context.Kategorijas.Add(subcategory);
                    await Context.SaveChangesAsync();

                    return Ok("Dodata je parent kategorija");

                }

           }
           catch(Exception e)
           {
               return BadRequest(e.Message);
           }
        }

        [Route("PreuzmiKategorije")]
        [HttpGet]

        public async Task<ActionResult> preuzmiKategorije()
        {
            try
            {
                var kategorije = await Context.Kategorijas.Include(c => c.Subcategories).ToListAsync();
                List<Kategorija> result = new List<Kategorija>();
                List<Kategorija> Rez = new List<Kategorija>();
                HashSet<int> processedCategoryIds = new HashSet<int>();

                foreach (var category in kategorije)
                {
                    if (!processedCategoryIds.Contains(category.Id))
                    {
                        result.Add(category);
                        processedCategoryIds.Add(category.Id);

                        AddSubcategoriesRecursive(category.Subcategories, result, processedCategoryIds);
                    }
                }

                foreach(var res in result)
                {
                    if(res.parentCategory == null)
                    {
                        Rez.Add(res);
                    }
                }
                return Ok(Rez);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        private void AddSubcategoriesRecursive(IEnumerable<Kategorija> subcategories, List<Kategorija> result, HashSet<int> processedCategoryIds)
        {
            foreach (var subcategory in subcategories)
            {
                if (!processedCategoryIds.Contains(subcategory.Id))
                {
                    result.Add(subcategory);
                    processedCategoryIds.Add(subcategory.Id);

                    AddSubcategoriesRecursive(subcategory.Subcategories, result, processedCategoryIds);
                }
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
