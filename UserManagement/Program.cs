//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
//using Microsoft.IdentityModel.Tokens;
//using System.Text;
//using UserManagement;
//using UserManagement.Data;
//using UserManagement.Interface.Manager;
//using UserManagement.Manager;
//using UserManagement.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Options;


//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddScoped<IUserManager, UserManager>();
//builder.Services.AddDbContext<DbContextClass>();
//builder.Services.AddControllers();
////for Identity
//builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<DbContextClass>().AddDefaultTokenProviders();
//// adding authentication
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultScheme=JwtBearerDefaults.AuthenticationScheme;

//})
//// adding jwt bearer
//  .AddJwtBearer(Options =>
// {
//     Options.SaveToken = true;
//     Options.RequireHttpsMetadata = false;
//     Options.TokenValidationParameters = new TokenValidationParameters()
//     {


//         ValidateIssuer = true,
//         ValidateAudience = true,
//         ValidAudience = builder.Configuration["Jwt:Audience"],
//         ValidIssuer = builder.Configuration["Jwt:Issuer"],
//         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
//         //ValidateIssuer = true,
//         //ValidateAudience = true,
//         //ValidAudience = builder.Configuration["JWT:ValidAudience"],
//         //ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
//         //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
//         ////ValidateIssuerSigningKey = true,
//         //////IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key)),
//         ////ValidateIssuer =false,
//         ////ValidateAudience=false,
//     };
// });
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
//app.UseHttpsRedirection();
//app.UseAuthentication();
//app.UseAuthorization();

//app.MapControllers();

//app.Run();
using UserManagement.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.


// Add Entity Framework Core
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

// Add Identity Framework Core..
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]))
    };
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    {
       app.UseSwagger();
       app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();