using Backend;
using Microsoft.EntityFrameworkCore;

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

// var connectionString = $"postgresql://{username}:{password}@{host}:{port}/{dbName}";

var connectionString = $"Host={host};Port={port};Database={dbName};Username={username};Password={password};SSL Mode=Require;Trust Server Certificate=true";

Console.WriteLine(connectionString);

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddExtensions();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
