
using GiveWaveAPI.Services;
using Microsoft.AspNetCore.Mvc;
using GiveWaveAPI.Models;

namespace GiveWaveAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly ChatService _chatService;
        public ChatController(ChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost("register-user")]
        public IActionResult RegisterUser()
        {
            var ime = Request.Form["ime"];

            if (_chatService.AddUserToList(ime))
            {
                //204 Status code
                return NoContent();
            }

            return BadRequest("This name is taken please choose another name");
        }
    }
}
