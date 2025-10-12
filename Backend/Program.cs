using Backend;
using Backend.Seeders;
using Backend.Extensions;
using Microsoft.EntityFrameworkCore;
using Backend.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dbSettings = builder.Configuration.GetDatabaseSettings();
var jwtSettings = builder.Configuration.GetJwtSettings();
var corsSettings = builder.Configuration.GetCorsSettings();

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(dbSettings.ConnectionString));
builder.Services.AddSingleton(jwtSettings);

builder.Services.AddExtensions();
builder.Services.AddJwtAuthentication(jwtSettings);
builder.Services.AddCorsForFrontend(corsSettings);
builder.Services.AddValidatorFormatter();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.SeedDBWithTestData();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseCors(corsSettings.PolicyName);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

await app.RunAsync();
