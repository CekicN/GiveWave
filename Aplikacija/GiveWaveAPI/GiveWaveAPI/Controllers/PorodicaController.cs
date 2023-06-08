using Microsoft.AspNetCore.Mvc;
using Models;
namespace GiveWaveAPI.Controllers
{
    public class PorodicaController : ControllerBase
    {
        private readonly GiveWaveDBContext context;
        public PorodicaController(GiveWaveDBContext c)
        {
            context = c;
        }
    }
}
