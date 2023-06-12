using GiveWaveAPI.Helpers;
using GiveWaveAPI.Models;
using GiveWaveAPI.Models.Authentication.Login;
using GiveWaveAPI.Models.Authentication.Signup;
using GiveWaveApiService.Models;
using GiveWaveApiService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Response = GiveWaveAPI.Models.Response;

namespace GiveWaveAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        private readonly GiveWaveDBContext _context;
        private readonly IWebHostEnvironment _environment;
        public AuthenticationController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IEmailService emailService, IConfiguration configuration, SignInManager<IdentityUser> signInManager, GiveWaveDBContext context, IWebHostEnvironment environment)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _emailService = emailService;
            _configuration = configuration;
            _signInManager = signInManager;
            _context = context;
            _environment = environment;
        }
        [HttpPost("signup")]
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser)
        {
            //check if user exist
            var userExist = await _userManager.FindByEmailAsync(registerUser.Email);
            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status403Forbidden,
                    new Response { Status = "Error", Message = "User alredy exists!" });
            }

            //add user in database
            IdentityUser user = new()
            {
                Email = registerUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUser.UserName,
                TwoFactorEnabled = false
            };

            if (await _roleManager.RoleExistsAsync("User"))
            {
                var result = await _userManager.CreateAsync(user, registerUser.Password);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new Response { Status = "Error", Message = "User failed to create!" });
                }
                //Kreiramo profil za registrovanog korisnika
                var profil = new ProfilKorisnika();
                profil.Email = user.Email;
                profil.Pol = "Male";
                profil.Username = user.UserName;
                profil.DatumRegistracije = new DateTime(DateTime.Now.Ticks);
                profil.BrojLajkova = 0;
                _context.Add(profil);
                _context.SaveChanges();
                //add role to the user
                await _userManager.AddToRoleAsync(user, "User");
                //add token to verify email
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action(nameof(ConfirmEmail), "Authentication", new { token, email = user.Email }, Request.Scheme);
                var message = new GiveWaveApiService.Models.Message(new string[] { user.Email }, "Confirmation email link", confirmationLink);
                _emailService.SendEmail(message);

                return StatusCode(StatusCodes.Status200OK,
                        new Response { Status = "Success", Message = $"User created succesfully & email sent to {user.Email} successfully!" });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        new Response { Status = "Error", Message = "This role doesn't exist!" });
            }
        }

        //assign role that we want
        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status200OK,
                        new Response { Status = "Success", Message = "Email verified successfully!" });
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError,
                        new Response { Status = "Error", Message = "This user doesn't exist!" });
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            //check if user exist
            var user = await _userManager.FindByNameAsync(loginModel.Username);
            //if (user.TwoFactorEnabled)
            //{
            //    await _signInManager.SignOutAsync();
            //    await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, true);
            //    var token = await _userManager.GenerateTwoFactorTokenAsync(user, "Email");
            //    //sending email
            //    var message = new Message(new string[] { user.Email! }, "OTP confirmation", token);
            //    _emailService.SendEmail(message);
            //    return StatusCode(StatusCodes.Status200OK,
            //        new Response { Status = "Success", Message = $"We have sent an OTP to your email {user.Email}" });
            //}
            //check the password
            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password) && user.EmailConfirmed)
            {
                //claimlist creation
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                var userRoles = await _userManager.GetRolesAsync(user);

                //we add roles to the list
                foreach (var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }

                //generate the token with the claims
                var jwtToken = GetToken(authClaims);
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    expiration = jwtToken.ValidTo
                });

            }
            return Unauthorized();








            //returning the token

        }
        //generate token
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }
        //[HttpPost]
        //[Route("RefreshToken")]
        //public string RefreshToken(JwtSecurityToken expiredToken)
        //{
        //    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        //    var tokenHandler = new JwtSecurityTokenHandler();

        //    var originalClaims = expiredToken.Claims.ToList();
        //    var newToken = new JwtSecurityToken(
        //        issuer: expiredToken.Issuer,
        //        audience: expiredToken.Audiences.FirstOrDefault(),
        //        claims: originalClaims,
        //        expires: DateTime.UtcNow.AddDays(7),
        //        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        //        );
        //    var refreshedToken = tokenHandler.WriteToken(newToken);
        //    return refreshedToken;
        //}

        //[HttpPost]
        //[Route("login-2FA")]
        //public async Task<IActionResult> LoginWithOTP(string code, string username)
        //{
        //    var user = await _userManager.FindByNameAsync(username);
        //    var signIn = await _signInManager.TwoFactorSignInAsync("Email", code, false, false);
        //    if (signIn.Succeeded)
        //    {
        //        if (user != null)
        //        {
        //            //claimlist creation
        //            var authClaims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, user.UserName),
        //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //        };
        //            var userRoles = await _userManager.GetRolesAsync(user);

        //            //we add roles to the list
        //            foreach (var role in userRoles)
        //            {
        //                authClaims.Add(new Claim(ClaimTypes.Role, role));
        //            }

        //            //generate the token with the claims
        //            var jwtToken = GetToken(authClaims);
        //            return Ok(new
        //            {
        //                token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
        //                expiration = jwtToken.ValidTo
        //            });

        //        }
        //    }
        //    return StatusCode(StatusCodes.Status404NotFound,
        //            new Response { Status = "Error", Message = "Invalid code" });
        //}
        [HttpPost]
        [Route("forgotpassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([Required] string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {


                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var forgotPasswordLink = Url.Action((nameof(ResettPassword)), "Authentication", new { token, email = user.Email }, Request.Scheme);// (nameof(ResettPassword)
                var message = new GiveWaveApiService.Models.Message(new string[] { user.Email! }, "Forgot password link",/*forgotPasswordLink!*/ EmailBody.EmailStringBody(email, token));//CreateBody(email,token));
                _emailService.SendEmail(message);
                return StatusCode(StatusCodes.Status200OK,
                    new Response { Status = "Success", Message = $"Password changed request is sent on Email {user.Email}. Please open your email & click on link" });
            }
            return StatusCode(StatusCodes.Status400BadRequest,
                    new Response { Status = "Error", Message = $"Could't send link to email, please try again." });
        }
        [HttpGet("reset-password")]
        public async Task<IActionResult> ResettPassword(string token, string email)
        {
            var model = new ResetPassword { token = token, email = email };
            return Ok(new
            {
                model
            });
        }
        [HttpPost("ResetPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword()
        {
            var token = Request.Form["token"];
            var email = Request.Form["email"];
            var newPassword = Request.Form["newPassword"];
            var confirmPassword = Request.Form["confirmPassword"];
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var resetPassResult = await _userManager.ResetPasswordAsync(user, token, newPassword);
                if (!resetPassResult.Succeeded)
                {
                    foreach (var error in resetPassResult.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return Ok(ModelState);
                }
                return StatusCode(StatusCodes.Status200OK,
                    new Response { Status = "Success", Message = $"Password has been changed" });
            }
            return StatusCode(StatusCodes.Status400BadRequest,
                    new Response { Status = "Error", Message = $"Could't send link to email, please try again." });
        }
        [NonAction]
        public string CreateBody(string email, string token)
        {
            string body = String.Empty;

            using (StreamReader sr = new StreamReader(_environment.WebRootPath + "\\EmailTemplate\\ContactEmail.html"))
            {
                body = sr.ReadToEnd();
            }

            body = body.Replace("{email}", email);
            body = body.Replace("{content}", token);

            return body;
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IdentityUser>> GetAllUsers()
        {
            return Ok(await _context.Users.ToListAsync());
        }
        public static MimeMessage CreateEmailMessage(string recipientEmail, string recipientName)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("GiveWave", "givewave@gmail.com"));
            message.To.Add(new MailboxAddress(recipientName, recipientEmail));
            message.Subject = "Welcome to our newsletter";

            // Load the HTML template from a file or a string
            string htmlTemplate = LoadEmailTemplate();

            // Replace the placeholders with actual values
            string emailBody = htmlTemplate.Replace("{Name}", recipientName)
                                           .Replace("{Email}", recipientEmail);

            // Create the HTML body part
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = emailBody;

            message.Body = bodyBuilder.ToMessageBody();

            return message;
        }
        private static string LoadEmailTemplate()
        {
            // Load the HTML template from a file, a database, or a string literal
            // In this example, we'll use a string literal
            string template = @"<html> 
<head>
    <style>
      /* CSS styles for your email */
      body {
        font-family: Arial, sans-serif;
        margin: 0;
        padding: 0;
      }
      .container {
        max-width: 600px;
        margin: 0 auto;
        padding: 20px;
        background-color: #f4f4f4;
      }
      h1 {
        color: #333;
        font-size: 24px;
      }
      p {
        color: #555;
        font-size: 16px;
        margin-bottom: 20px;
      }
      .button {
        display: inline-block;
        background-color: #0d6efd;
        color: #fff;
        text-decoration: none;
        padding: 10px 20px;
        border-radius: 4px;
        font-size: 16px;
      }
    </style>
  </head>
  <body>
    <div class=""container"">
      <h1>Reset Your Password</h1>
      <p>
        You're receiving this email because a password reset request has been made
        for your account.
      </p>
      <p>Please click the button below to reset your password:</p>
      <p>
        <a class=""button"" href=""{resetLink}"">Reset Password</a>
      </p>
      <p>
        If you didn't request a password reset, please ignore this email. Your
        password will remain unchanged.
      </p>
    </div>
  </body>
</html>";

            return template;
        }

    }
}
