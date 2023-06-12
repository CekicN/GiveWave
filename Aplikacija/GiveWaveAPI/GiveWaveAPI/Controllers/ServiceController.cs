using Microsoft.AspNetCore.Mvc;
using GiveWaveAPI.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace GiveWaveAPI.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("controller")]
    [Authorize(Roles = "Service")]
    public class ServiceController : Controller
    {
        private readonly GiveWaveDBContext context;
        public ServiceController(GiveWaveDBContext c)
        {
            context = c;
        }

        [HttpPut]
        [Route("validateFamily/{id}/{status}")]
        public async Task<ActionResult> validateFamily(int id,string status)
        {
            try
            {
                if (status != "Less vulnerable" && status != "Moderately vulnerable" && status != "Highly vulnerable")
                    return BadRequest("status nije validan");
                var family = context.Porodice.Where(p => p.Id == id).FirstOrDefault();
                if (family == null)
                    return BadRequest("Porodica nije nadjena");
                family.Potvrda = true;
                family.Status = status;
                context.Porodice.Update(family);
                await context.SaveChangesAsync();
                return Ok();
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("getAllFamiliesToValidate")]
        public async Task<ActionResult> getAllFamiliesToValidate()
        {
            try
            {
                var validFamilies = context.Porodice.Where(p => p.Potvrda == false).ToList();
                if (validFamilies == null)
                    return BadRequest("Nema potvrdjenih porodica");

                return Ok(validFamilies);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        [Route("removeFamily/{id}")]
        public async Task<ActionResult> removeFamily(int id)
        {
            try
            {
                var family = context.Porodice.Where(p => p.Id == id).FirstOrDefault();

                if (family == null)
                    return BadRequest("porodica nije nadjena");

                context.Porodice.Remove(family);
                await context.SaveChangesAsync();

                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
