using System.Text.Json;
using GiveWaveAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.SpaServices;
using GiveWaveAPI.Services;
using GiveWaveAPI.Hubs;
using Microsoft.AspNetCore.Cors;
using GiveWaveApiService.Models;
using GiveWaveApiService.Services;



var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddDbContext<GiveWaveDBContext>(options =>
{
     options.UseSqlServer(builder.Configuration.GetConnectionString("ProjekatSWE"));
});
//builder.Services.AddCoreAdmin();
builder.Services.AddCoreAdmin();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORS", policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .AllowAnyOrigin()
              .AllowCredentials()
              .WithOrigins("https://localhost:5555/",
                           "https://localhost:5555/",
                           "https://localhost:4200",
                           "http://localhost:4200",
                           "http://localhost:7200");
    });
});
//add config for required email
builder.Services.Configure<IdentityOptions>(
    opts => opts.SignIn.RequireConfirmedEmail = true);

builder.Services.Configure<DataProtectionTokenProviderOptions>(opts => opts.TokenLifespan = TimeSpan.FromHours(10));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//za chat
builder.Services.AddSingleton<ChatService>();
builder.Services.AddSignalR();
builder.Services.AddCors();

builder.Services.AddSwaggerGen();
builder.Services.Configure<JwtBearerPostConfigureOptions>(builder.Configuration.GetSection("JWTConfig"));
//builder.Services.AddSwaggerGen();
//builder.Services.Configure<JWTConfig>(builder.Configuration.GetSection("JWTConfig"));

//add email config
var emailConfig = configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);

builder.Services.AddScoped<IEmailService, EmailService>();

//adding authentication
builder.Services.AddAuthentication(configureOptions: options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };
});
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedEmail = false)
//  .AddEntityFrameworkStores<GiveWaveDBContext>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
  .AddEntityFrameworkStores<GiveWaveDBContext>()
  .AddDefaultTokenProviders();

//builder.Services.AddIdentity<User, IdentityUser>(options =>
//{
//    options.Password.RequireNonAlphanumeric = false;

//}).AddRoles<IdentityRole>()
//    .AddEntityFrameworkStores<GiveWaveDBContext>()
//    .AddRoleManager<RoleManager<IdentityRole>>()
//    .AddDefaultTokenProviders();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "GiveWaveAPI", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("User", policy =>
    {
        policy.AuthenticationSchemes = new List<string>() { JwtBearerDefaults.AuthenticationScheme };
        policy.RequireRole("User");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseRouting();
app.UseStaticFiles();

app.UseCors("CORS");



app.UseHttpsRedirection();

app.UseAuthentication();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.MapHub<ChatHub>("/hubs/chat");

app.Run();


