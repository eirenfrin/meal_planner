using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Recipe> Recipes { get; set; }
}