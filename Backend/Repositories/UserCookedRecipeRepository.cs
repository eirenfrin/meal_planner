using Backend.Dtos;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class UserCookedRecipeRepository(AppDbContext context) : IUserCookedRecipeRepository
{
    private readonly AppDbContext _context = context;

    public async Task PlanRecipe(UserCookedRecipe plannedRecipe)
    {
        _context.UserCookedRecipes.Add(plannedRecipe);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<UserCookedRecipe>> GetRecipesPlannedForDate(Guid userId, DateTime plannedForDate)
    {
        var plannedRecipes = await _context.UserCookedRecipes
        .Include(ucr => ucr.Recipe)
            .ThenInclude(r => r!.UnitsRecipes)
                .ThenInclude(ur => ur.Unit)
        .Where(ucr => ucr.UserId == userId && ucr.PlannedStartDate == plannedForDate)
        .ToListAsync();

        return plannedRecipes;
    }
}