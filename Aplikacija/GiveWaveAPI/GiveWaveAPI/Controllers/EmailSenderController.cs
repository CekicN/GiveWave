using GiveWaveAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace GiveWaveAPI.Controllers
{
    public class EmailSenderController : Controller
    {

        private readonly IWebHostEnvironment _environment;
        public EmailSenderController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
      
        [Route("SendEmail")]
        [HttpPost]
        public async Task<ActionResult> SendEmail([FromBody] EmailContent emailContent)
        {
            var ret = send(emailContent.Name,emailContent.Email, emailContent.Subject,emailContent.Text); 
            if(ret == "true")
            {
                return Ok("Email je Poslat");
            }
            return BadRequest(ret);
        }

        [NonAction]
        private String send(String name,String email, String Subject, String text)
        {
            try
            {
                string from = email;
                string to = "givewave.mail@gmail.com";
                string appPassword = "uyfuockdepjpnklh";
                string subject = Subject;
                string body = text;
                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential(to, appPassword);

                    using (var message = new MailMessage(from, to))
                    {
                        message.Subject = subject;
                        message.Body = CreateBody(name, email, text);
                        message.IsBodyHtml = true;
                        
                        smtp.Send(message);
                    }
                }


                return "true";
            }
            catch(Exception e)
            {
                
                return e.Message;
            }
        }

        [NonAction]
        public string CreateBody(string name, string email, string text)
        {
            string body = String.Empty;

            using(StreamReader sr = new StreamReader(_environment.WebRootPath+ "\\EmailTemplate\\ContactEmail.html"))
            {
                body = sr.ReadToEnd();
            }

            body = body.Replace("{name}", name);
            body = body.Replace("{email}", email);
            body = body.Replace("{content}", text);

            return body;
        }
    }
}
