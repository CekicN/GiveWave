using GiveWaveAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GiveWaveAPI.Controllers
{
    public class DonacijaController : ControllerBase
    {
        private readonly GiveWaveDBContext context;

        public DonacijaController(GiveWaveDBContext c)
        {
            context = c;
        }
        
        [Route("VratiSveDonacije")]
        [HttpGet]
        public async Task<ActionResult> vratiSveDonacije()
        {
            try
            {
                var donacije = context.Donacijas.ToListAsync();
                await context.SaveChangesAsync();
                return Ok(donacije);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }


    }
}