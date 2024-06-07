using Microsoft.EntityFrameworkCore;
using RealEstate.Data.Data;
using RealEstate.Extensions;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlServer(connectionString));

//Jwt configuration starts here

var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();
var issuer = builder.Configuration.GetSection("Jwt:ValidIssuer").Get<string>();
var aud = builder.Configuration.GetSection("Jwt:ValidAudience").Get<string>();

builder.Services.AddJwtAuthentication(issuer, aud, jwtKey);

//Jwt configuration ends here

builder.Services.AddIdentity();
// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("free", opt =>
    {
        opt.AllowAnyOrigin();
        opt.AllowAnyHeader();
        opt.AllowAnyMethod();
    });
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
});

builder.Services.AddControllers();
builder.Services.AddAuthorization();
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
