//using GiveWaveAPI.Models;
//using GiveWaveAPI.Models.Configuration;
//using GiveWaveAPI.Models.DTOs;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.Tokens;
//using System.Data;
//using System.Diagnostics.Eventing.Reader;
//using System.IdentityModel.Tokens.Jwt;
//using System.Reflection;
//using System.Security.Claims;
//using System.Text;
//using System.Text.Json;

//namespace GiveWaveAPI.Controllers;

//[Route(template:"api/[controller]")]//api/authentication
//[ApiController]
//public class AuthenticationController : ControllerBase
//{
//    private readonly UserManager<IdentityUser>  _userManager;
//    //private readonly JWTConfig _jwtConfig;
//    private readonly IConfiguration _configuration;
//    private readonly GiveWaveDBContext context;
//    public AuthenticationController(
//        UserManager<IdentityUser> userManager,
//        IConfiguration configuration,
//        GiveWaveDBContext c
//       // JWTConfig jwtConfig
//       )
//    {
//        _userManager = userManager;
//        _configuration = configuration;
//        //_jwtConfig = jwtConfig;
//        context = c;

//    }
//    [Route(template:"Register")]
//    [HttpPost]
//    public async Task<IActionResult> Register([FromBody] UserRegisterRequestDto registerRequest)
//    {
//        //validate incoming req
//        if(ModelState.IsValid)
//        {
//            //provera da l postoji korisnik pri register-u
//            var user_exist = await _userManager.FindByEmailAsync(registerRequest.Email); 
//            if(user_exist != null)
//            {
//                return BadRequest(error: new AuthResult()
//                {
//                    Result = false,
//                    Errors = new List<string>()
//                    {
//                        "Email alredy exist, please Login"
//                    }
//                });
//            }
//            //ako ne postoji user, pravimo novog user-a
//            var new_user = new IdentityUser()
//            {

//                //FirstName = registerRequest.FirstName,
//                //LastName = registerRequest.LastName,
//                Email = registerRequest.Email,
//                UserName = registerRequest.Username,
//               // Password = registerRequest.Password,

//            };
//            var is_created = await _userManager.CreateAsync(new_user,registerRequest.Password);

//            if(is_created.Succeeded) 
//            {
//                if(new_user.Id != null)
//                {
//                    //Kreiramo profil za registrovanog korisnika
//                    var profil = new ProfilKorisnika();
//                    profil.Email = new_user.Email;
//                    profil.Pol = "Male";
//                    profil.Username = new_user.UserName;
//                    profil.DatumRegistracije = new DateTime(DateTime.Now.Ticks);
//                    profil.BrojLajkova = 0;
//                    context.Add(profil);
//                    context.SaveChanges();
//                }
//               //generisemo token
//               var token = GenerateJWTToken(new_user);
//                {
//                    return Ok(new AuthResult()
//                    {
//                        Result = true,
//                        Token = token
//                    });
//                }
//            }
//            return BadRequest(error:new AuthResult()
//            {
//                Errors = new List<string>() 
//                { 
//                    "Server error"
//                },
//                Result = false
//            });

//        }
//        return BadRequest();
//    }
//    [Route("Login")]
//    [HttpPost]
//    public async Task<IActionResult> Login([FromBody] UserLoginRequestDto loginRequest)
//    {
//        if (ModelState.IsValid)
//        {
//            //da li user postoji?
//            var existing_user = await _userManager.FindByEmailAsync(loginRequest.Email);
//            //ako ne postoji
//            if (existing_user == null)
//            {
//                return BadRequest(new AuthResult()
//                {
//                    Errors = new List<string>()
//                    {
//                        "Invalid payload"
//                    },
//                    Result = false
//                });
//            }
//            var is_correct =  await _userManager.CheckPasswordAsync(existing_user, loginRequest.Password);


//            if (!is_correct)
//            {
//                return BadRequest(new AuthResult()
//                {
//                    Errors = new List<string>()
//                       {
//                           "Invalid credentials"
//                       },
//                    Result = false
//                });
//            }
//            var jwtToken = GenerateJWTToken(existing_user);

//             return Ok(new AuthResult()
//             {
//                  Token = jwtToken,
//                  Result = true
//             });



//        }
//        return BadRequest(new AuthResult()
//        {
//            Errors = new List<string>()
//            {
//                "Invalid payload"
//            },
//            Result = false
//        }) ;
//    }
//    //funkcija za generisanje tokena
//    private string GenerateJWTToken(IdentityUser user)
//    {
//        //tocken handler
//        var jwtTokenHandler = new JwtSecurityTokenHandler();
//        var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JWTConfig:Secret").Value);

//            //Token descriptor
//        var tokenDescriptor = new SecurityTokenDescriptor()
//            {
//                Subject = new ClaimsIdentity(new[]
//                {

//                new Claim("Id",user.Id),
//                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
//                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
//                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
//                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString())

//            }),
//                //trajanje tokena 1 sat od generisanja
//                Expires = DateTime.Now.AddHours(1),
//                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)

//            };

//            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
//            return jwtTokenHandler.WriteToken(token);



//    }
//}
using Azure;
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
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
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
            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
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
                var message = new GiveWaveApiService.Models.Message(new string[] { user.Email! }, "Forgot password link",/*forgotPasswordLink!*/ /*EmailBody.EmailStringBody(email,token)*/CreateBody(email,token));
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
    }
}
