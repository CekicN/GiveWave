using GiveWaveAPI.Models;
using GiveWaveAPI.Models.Configuration;
using GiveWaveAPI.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace GiveWaveAPI.Controllers;

[Route(template:"api/[controller]")]//api/authentication
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly UserManager<IdentityUser>  _userManager;
    //private readonly JWTConfig _jwtConfig;
    private readonly IConfiguration _configuration;
    public AuthenticationController(
        UserManager<IdentityUser> userManager,
        IConfiguration configuration
       // JWTConfig jwtConfig
       )
    {
        _userManager = userManager;
        _configuration = configuration;
        //_jwtConfig = jwtConfig;
        
    }
    [Route(template:"Register")]
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] UserRegisterRequestDto registerRequest)
    {
        //validate incoming req
        if(ModelState.IsValid)
        {
            //provera da l postoji korisnik pri register-u
            var user_exist = await _userManager.FindByEmailAsync(registerRequest.Email); 
            if(user_exist != null)
            {
                return BadRequest(error: new AuthResult()
                {
                    Result = false,
                    Errors = new List<string>()
                    {
                        "Email alredy exist, please Login"
                    }
                });
            }
            //ako ne postoji user, pravimo novog user-a
            var new_user = new IdentityUser()
            {

                //FirstName = registerRequest.FirstName,
                //LastName = registerRequest.LastName,
                Email = registerRequest.Email,
                UserName = registerRequest.Username,
               // Password = registerRequest.Password,
               

            };
            var is_created = await _userManager.CreateAsync(new_user,registerRequest.Password);

            if(is_created.Succeeded) 
            {
               //generisemo token
               var token = GenerateJWTToken(new_user);
                {
                    return Ok(new AuthResult()
                    {
                        Result = true,
                        Token = token
                    });
                }
            }
            return BadRequest(error:new AuthResult()
            {
                Errors = new List<string>() 
                { 
                    "Server error"
                },
                Result = false
            });

        }
        return BadRequest();
    }
    [Route("Login")]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] UserLoginRequestDto loginRequest)
    {
        if (ModelState.IsValid)
        {
            //da li user postoji?
            var existing_user = await _userManager.FindByEmailAsync(loginRequest.Email);
            //ako ne postoji
            if (existing_user == null)
            {
                return BadRequest(new AuthResult()
                {
                    Errors = new List<string>()
                    {
                        "Invalid payload"
                    },
                    Result = false
                });
            }
            var is_correct =  await _userManager.CheckPasswordAsync(existing_user, loginRequest.Password);


            if (!is_correct)
            {
                return BadRequest(new AuthResult()
                {
                    Errors = new List<string>()
                       {
                           "Invalid credentials"
                       },
                    Result = false
                });
            }
            var jwtToken = GenerateJWTToken(existing_user);

             return Ok(new AuthResult()
             {
                  Token = jwtToken,
                  Result = true
             });
             

            
        }
        return BadRequest(new AuthResult()
        {
            Errors = new List<string>()
            {
                "Invalid payload"
            },
            Result = false
        }) ;
    }
    //funkcija za generisanje tokena
    private string GenerateJWTToken(IdentityUser user)
    {
        //tocken handler
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JWTConfig:Secret").Value);
        
            //Token descriptor
        var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {

                new Claim("Id",user.Id),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString())

            }),
                //trajanje tokena 1 sat od generisanja
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)

            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        
        

    }
}
