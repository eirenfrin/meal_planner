using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Ingredient> Ingredients { get; set; }

    public DbSet<Recipe> Recipes { get; set; }

    public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

    public DbSet<ShoppingList> ShoppingLists { get; set; }

    public DbSet<ShoppingListIngredient> ShoppingListIngredients { get; set; }

    public DbSet<Unit> Units { get; set; }

    public DbSet<UnitsRecipe> UnitsRecipes { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<UserCookedRecipe> UserCookedRecipes { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Recipe delete cascade delete for RecipeIngredients
        modelBuilder.Entity<RecipeIngredient>()
            .HasOne(ri => ri.Recipe)
            .WithMany(r => r.RecipeIngredients)
            .HasForeignKey(ri => ri.RecipeId)
            .OnDelete(DeleteBehavior.Cascade);

        // Recipe delete cascade delete for UnitsRecipes
        modelBuilder.Entity<UnitsRecipe>()
            .HasOne(ur => ur.Recipe)
            .WithMany(r => r.UnitsRecipes)
            .HasForeignKey(ur => ur.RecipeId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}