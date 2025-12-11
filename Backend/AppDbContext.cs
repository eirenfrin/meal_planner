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

    public DbSet<RefreshToken> RefreshTokens { get; set; }

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

        // Unit delete - refuse if unit referenced elsewhere
        modelBuilder.Entity<UnitsRecipe>()
            .HasOne(ur => ur.Unit)
            .WithMany(u => u.UnitsRecipes)
            .HasForeignKey(ur => ur.UnitId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<RecipeIngredient>()
            .HasOne(ri => ri.Unit)
            .WithMany(u => u.RecipeIngredients)
            .HasForeignKey(ri => ri.UnitId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Ingredient>()
            .HasOne(i => i.Unit)
            .WithMany(u => u.Ingredients)
            .HasForeignKey(i => i.UnitId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ShoppingListIngredient>()
            .HasOne(sli => sli.Unit)
            .WithMany(u => u.ShoppingListIngredients)
            .HasForeignKey(sli => sli.UnitId)
            .OnDelete(DeleteBehavior.Restrict);

        // Ingredient delete - refuse if ingredient referenced elsewhere
        modelBuilder.Entity<RecipeIngredient>()
            .HasOne(ri => ri.Ingredient)
            .WithMany(i => i.RecipeIngredients)
            .HasForeignKey(ri => ri.IngredientId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ShoppingListIngredient>()
            .HasOne(sli => sli.Ingredient)
            .WithMany(i => i.ShoppingListIngredients)
            .HasForeignKey(sli => sli.IngredientId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}