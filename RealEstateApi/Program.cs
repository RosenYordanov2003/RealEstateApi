using Microsoft.EntityFrameworkCore;
using RealEstate.Core.Contracts;
using RealEstate.Core.Services;
using RealEstate.Data.Data;
using RealEstate.Extensions;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlServer(connectionString));

var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();
var issuer = builder.Configuration.GetSection("Jwt:ValidIssuer").Get<string>();
var aud = builder.Configuration.GetSection("Jwt:ValidAudience").Get<string>();

builder.Services.AddJwtAuthentication(issuer, aud, jwtKey);
builder.Services.AddIdentity();
builder.Services.AddCorsConfiguration();

builder.Services.AddApplicationCookieConfiguration();

builder.Services.AddControllers();
builder.Services.AddAuthorization();

builder.Services.AddScoped<IAccountService, AccountService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerConfiguration();

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
app.UseCors("free");

app.MapControllers();

app.Run();
