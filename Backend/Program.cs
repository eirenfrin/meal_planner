using Backend;
using Backend.Seeders;
using Backend.Extensions;
using Microsoft.EntityFrameworkCore;
using Backend.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var username = builder.Configuration["DB:Username"];
var password = builder.Configuration["DB:Password"];
var port = builder.Configuration["DB:Port"];
var host = builder.Configuration["DB:Host"];
var dbName = builder.Configuration["DB:Name"];

var issuer = builder.Configuration["Jwt:Issuer"]!;
var audience = builder.Configuration["Jwt:Audience"]!;
var signingKey = builder.Configuration["Jwt:SigningKey"]!;

var connectionString = $"Host={host};Port={port};Database={dbName};Username={username};Password={password};SSL Mode=Require;Trust Server Certificate=true";

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddExtensions();

builder.Services.AddJwtAuthentication(issuer, audience, signingKey);

builder.Services.AddCorsForFrontend();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // retrieve the services instance from the built app
    using var scope = app.Services.CreateScope();
    // get the db context instance from the services
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    // execute seeders
    context.SeedDBWithTestData();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

await app.RunAsync();
