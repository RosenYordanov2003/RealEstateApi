using Microsoft.EntityFrameworkCore;
using RealEstate.Data.Data;
using RealEstate.Extensions;
using RealEstate.Middlewares;

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

builder.Services.AddServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var descriptions = app.DescribeApiVersions();

        // Build a swagger endpoint for each discovered API version
        foreach (var description in descriptions)
        {
            var url = $"/swagger/{description.GroupName}/swagger.json";
            var name = description.GroupName.ToUpperInvariant();
            options.SwaggerEndpoint(url, name);
        }
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("free");
app.UseMiddleware<GlobalExceptionHandler>();
app.MapControllers();
app.Run();
