using GiveWaveAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GiveWaveAPI.Controllers
{
    [Route("controller")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly GiveWaveDBContext context;
        public AboutController(GiveWaveDBContext c)
        {
            context = c;
        }


        [Route("CountUsers")]
        [HttpGet]
        public async Task<ActionResult> CountUsers()
        {
            try
            {
                
                List<ProfilKorisnika> Users = context.ProfilKorisnikas.ToList();
                int count = Users.Count;
                return Ok(count);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("CountProducts")]
        [HttpGet]
        public async Task<ActionResult> CountProducts()
        {
            try
            {

                List<Proizvod> Products = context.Proizvods.ToList();
                int count = Products.Count;
                return Ok(count);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //******************************
        //Kad Se napravi model za porodice ovo da se odkomentarise i da se namesti
        //******************************

        //[Route("CountFamilies")]
        //[HttpGet]
        //public async Task<ActionResult> CountFamilies()
        //{
        //    try
        //    {

        //        List<ProfilKorisnika> Users = context.ProfilKorisnikas.ToList();
        //        int count = Users.Count;
        //        return Ok(count);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
