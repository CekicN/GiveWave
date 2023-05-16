using GiveWaveAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace GiveWaveAPI.Controllers
{
    public class EmailSenderController : Controller
    {
      
        [Route("SendEmail")]
        [HttpPost]
        public async Task<ActionResult> SendEmail([FromBody] EmailContent emailContent)
        {
            send(emailContent.Email, emailContent.Text);

            return Ok("Email je Poslat");
        }

        [NonAction]
        private void send(String email, String text)
        {
            string from = email;
            string to = "givewave.mail@gmail.com";
            string subject = "Contact Us";
            string body = text;

            using (MailMessage message = new MailMessage(from,to,subject,body))
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("Give Wave", "GiveWave2023");

                smtp.Send(message);
            }
        }
    }
}
